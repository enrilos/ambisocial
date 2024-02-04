namespace AmbiSocial.Domain.Profiles.Specifications;

using System;
using System.Linq.Expressions;

using Common;
using Models;

public class ProfileByUserNameSpecification : Specification<Profile>
{
    private readonly string? userName;

    public ProfileByUserNameSpecification(string? userName) => this.userName = userName;

    protected override bool Include => this.userName != null;

    public override Expression<Func<Profile, bool>> ToExpression()
        => profile => profile.UserName == this.userName;
}