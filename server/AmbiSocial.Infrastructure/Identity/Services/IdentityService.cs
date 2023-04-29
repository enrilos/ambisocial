namespace AmbiSocial.Infrastructure.Identity.Services;

using Application.Common.Models;
using Application.Identity;
using Application.Identity.Commands.Common;
using Common.Events;
using Domain.Identity.Events;
using Microsoft.AspNetCore.Identity;

internal class IdentityService : IIdentity
{
    private const string InvalidAuthMessage = "Invalid credentials";

    private readonly UserManager<User> userManager;
    private readonly IJwtGenerator jwtGenerator;
    private readonly IEventDispatcher eventDispatcher;

    public IdentityService(
        UserManager<User> userManager,
        IJwtGenerator jwtGenerator,
        IEventDispatcher eventDispatcher)
    {
        this.userManager = userManager;
        this.jwtGenerator = jwtGenerator;
        this.eventDispatcher = eventDispatcher;
    }

    public async Task<Result<UserResponseModel>> Login(UserRequestModel userRequest)
    {
        var user = userRequest.Email is null
            ? await this.userManager.FindByNameAsync(userRequest.UserName)
            : await this.userManager.FindByEmailAsync(userRequest.Email);

        if (user == null)
        {
            return InvalidAuthMessage;
        }

        var passwordValid = await this.userManager.CheckPasswordAsync(
            user,
            userRequest.Password);

        if (!passwordValid)
        {
            return InvalidAuthMessage;
        }

        var token = await this.jwtGenerator.Generate(user);

        return new UserResponseModel(token);
    }

    public async Task<Result<UserResponseModel>> Register(UserRequestModel userRequest)
    {
        var user = new User(userRequest.Email, userRequest.UserName);

        var identityResult = await this.userManager.CreateAsync(
            user,
            userRequest.Password);

        if (!identityResult.Succeeded)
        {
            var errors = identityResult.Errors.Select(e => e.Description);

            return Result<UserResponseModel>.Failure(errors);
        }

        var userRegisteredEvent = new UserRegisteredEvent(userRequest.UserName);

        await this.eventDispatcher.Dispatch(userRegisteredEvent);

        var token = await this.jwtGenerator.Generate(user);

        return new UserResponseModel(token);
    }
}