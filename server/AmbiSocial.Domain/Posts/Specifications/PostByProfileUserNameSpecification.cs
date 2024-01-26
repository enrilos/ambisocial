namespace AmbiSocial.Domain.Posts.Specifications.Posts;

using System;
using System.Linq.Expressions;
using Common;
using Models;

public class PostByProfileUserNameSpecification : Specification<Post>
{
    private readonly string profileUserName;

    public PostByProfileUserNameSpecification(string profileUserName)
        => this.profileUserName = profileUserName;

    protected override bool Include => this.profileUserName != null;

    public override Expression<Func<Post, bool>> ToExpression()
        => post => post.Profile.UserName == this.profileUserName;
}