﻿namespace AmbiSocial.Domain.Posts.Repositories;

using Common;
using Models.Posts;

public interface IPostDomainRepository : IDomainRepository<Post>
{
    Task<Post?> Find(int id, CancellationToken cancellationToken = default);

    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}
