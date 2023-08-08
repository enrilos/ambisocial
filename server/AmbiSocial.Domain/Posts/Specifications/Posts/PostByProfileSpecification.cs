namespace AmbiSocial.Domain.Posts.Specifications.Posts;

using System;
using System.Linq.Expressions;
using Common;
using Models;

public class PostByProfileSpecification : Specification<Post>
{
    private readonly string profile;

    public PostByProfileSpecification(string profile) => this.profile = profile;

    protected override bool Include => this.profile != null;

    public override Expression<Func<Post, bool>> ToExpression()
        => post => post.Profile.UserName.ToLower()
            .Contains(this.profile.ToLower());
}