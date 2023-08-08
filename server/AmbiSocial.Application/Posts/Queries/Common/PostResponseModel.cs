namespace AmbiSocial.Application.Posts.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Posts.Models;

public class PostResponseModel : IMapFrom<Post>
{
    public string ImageUrl { get; private set; } = default!;

    public string AuthorUserName { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public void Mapping(Profile mapper)
        => mapper
            .CreateMap<Post, PostResponseModel>()
            .ForMember(m => m.AuthorUserName, cfg => cfg.MapFrom(s => s.Profile.UserName));
}