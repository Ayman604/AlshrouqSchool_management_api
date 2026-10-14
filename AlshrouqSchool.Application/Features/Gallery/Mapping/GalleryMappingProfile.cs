using AlshrouqSchool.Domain.Entities.MediaAndContentModule;
using AlshrouqSchool.Shared.DTOs.Gallery.Media;
using AlshrouqSchool.Shared.DTOs.Gallery.PostMedia;
using AlshrouqSchool.Shared.DTOs.Gallery.Posts;
using AutoMapper;
namespace AlshrouqSchool.Application.Features.Gallery.Mapping;
public sealed class GalleryMappingProfile : Profile
{
    public GalleryMappingProfile()
    {
        CreateMap<Post, PostDto>(); CreateMap<Post, PostSummaryDto>();
        CreateMap<Post, PostDetailsDto>().ForMember(d => d.Media, o => o.MapFrom(s => s.Media));
        CreateMap<Media, MediaDto>(); CreateMap<Media, MediaSummaryDto>();
        CreateMap<PostMedia, PostMediaDto>();
        CreateMap<CreatePostDto, Post>(); CreateMap<UpdatePostDto, Post>();
        CreateMap<CreateMediaDto, Media>(); CreateMap<UpdateMediaDto, Media>();
    }
}