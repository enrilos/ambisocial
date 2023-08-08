namespace AmbiSocial.Application.Posts.Queries.Search;

using System.Linq.Expressions;
using System;

using Domain.Posts.Models;
using Application.Common;

public class PostSearchSortOrder : SortOrder<Post>
{
    public PostSearchSortOrder(string? sortBy, string? order)
        : base(sortBy, order)
    {
    }

    public override Expression<Func<Post, object>> ToExpression()
        => this.SortBy switch
        {
            "author" => post => post.Profile.UserName,
            _ => post => post.Id
        };
}