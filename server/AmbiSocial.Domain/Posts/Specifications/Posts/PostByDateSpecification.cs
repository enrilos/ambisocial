namespace AmbiSocial.Domain.Posts.Specifications.Posts;

using System;
using System.Linq.Expressions;

using Common;
using Models.Posts;

public class PostByDateSpecification : Specification<Post>
{
    private readonly DateTime from;
    private readonly DateTime to;

    public PostByDateSpecification(DateTime from, DateTime to)
    {
        this.from = from;
        this.to = to;
    }

    public override Expression<Func<Post, bool>> ToExpression()
        => post => this.from < post.Date && post.Date < this.to;
}