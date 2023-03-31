namespace AmbiSocial.Application.Identity;
    
using Common.Models;
using Commands.Common;

public interface IIdentity
{
    Task<Result<UserResponseModel>> Register(UserRequestModel userRequest);

    Task<Result<UserResponseModel>> Login(UserRequestModel userRequest);
}