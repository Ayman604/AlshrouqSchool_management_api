using AlshrouqSchool.Application.Posts.Commands;
using AlshrouqSchool.Application.Posts.DTOs;
using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Posts.Queries
{
    public record GetAllPostsQuery():IRequest<IQueryable<PostDto>>;

    public class GetAllPostsQueryHandler(IPostRepository postRepository) : IRequestHandler<GetAllPostsQuery, IQueryable<PostDto>>
    {
        public async Task<IQueryable<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
           // var queryableablePosts = await postRepository.GetAllAsync();

            // Map Entity to DTO and execute asynchronously
            //return await queryableablePosts
            //    .Select(p => new PostDto(p.Id, p.Title, p.Content, p.CreatedAt))
            //    .ToListAsync(cancellationToken);
            return (IQueryable<PostDto>)await postRepository.GetAllAsync();
        }
    }
}
