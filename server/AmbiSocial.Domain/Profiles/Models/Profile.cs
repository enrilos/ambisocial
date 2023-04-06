﻿namespace AmbiSocial.Domain.Profiles.Models;

using Common;
using Common.Models;
using Exceptions;
using Posts.Models.Posts;

using static Common.Models.ModelConstants.Common;

public class Profile : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Post> posts;
    private readonly HashSet<Profile> followers;
    private readonly HashSet<Profile> following;

    internal Profile(string userName, string avatarUrl, string description)
    {
        this.Validate(userName, avatarUrl, description);

        this.UserName = userName;
        this.AvatarUrl = avatarUrl;
        this.Description = description;

        this.posts = new();
        this.followers = new();
        this.following = new();
    }

    public string UserName { get; private set; }

    public string AvatarUrl { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyCollection<Post> Posts => this.posts.ToList().AsReadOnly();

    public IReadOnlyCollection<Profile> Followers => this.followers.ToList().AsReadOnly();

    public IReadOnlyCollection<Profile> Following => this.following.ToList().AsReadOnly();

    public Profile UpdateDescription(string description)
    {
        this.ValidateDescription(description);

        this.Description = description;

        return this;
    }

    private void Validate(string userName, string avatarUrl, string description)
    {
        this.ValidateUserName(userName);
        this.ValidateAvatarUrl(avatarUrl);

        if (description is not null)
        {
            this.ValidateDescription(description);
        }
    }

    private void ValidateUserName(string userName)
        => Guard.ForStringLength<InvalidProfileException>(
            userName,
            MinNameLength,
            MaxNameLength,
            nameof(this.UserName));

    private void ValidateAvatarUrl(string url)
        => Guard.ForValidUrl<InvalidProfileException>(
            url,
            nameof(this.AvatarUrl));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidProfileException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}