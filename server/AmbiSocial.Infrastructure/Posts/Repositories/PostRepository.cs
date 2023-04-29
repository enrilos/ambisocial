namespace AmbiSocial.Infrastructure.Posts.Repositories;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Application.Posts;
using Application.Posts.Queries.Common;
using Application.Posts.Queries.Search;
using AutoMapper;
using Common.Events;
using Common.Extensions;
using Common.Repositories;
using Domain.Common;
using Domain.Posts.Models.Posts;
using Domain.Posts.Repositories;
using Microsoft.EntityFrameworkCore;

internal class PostRepository : DataRepository<IPostsDbContext, Post>,
    IPostDomainRepository,
    IPostQueryRepository
{
    public PostRepository(
        IPostsDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
    {
        var post = await this.Data.Posts.FindAsync(id);

        if (post is null)
        {
            return false;
        }

        this.Data.Posts.Remove(post);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<PostResponseModel?> Details(int id, CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<PostResponseModel>(this
                .AllAsNoTracking()
                .Where(p => p.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Post?> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<PostResponseModel>> List(
        Specification<Post> specification,
        PostSearchSortOrder sortOrder,
        int skip,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<PostResponseModel>(this
                .Query(specification)
                .Sort(sortOrder)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    public async Task<int> Total(Specification<Post> specification, CancellationToken cancellationToken = default)
        => await this.Query(specification).CountAsync(cancellationToken);

    private IQueryable<Post> Query(Specification<Post> specification)
        => this.AllAsNoTracking().Where(specification);
}