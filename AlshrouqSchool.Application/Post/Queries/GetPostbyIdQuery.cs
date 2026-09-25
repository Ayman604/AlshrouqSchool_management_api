using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Application.Posts.DTOs;
using AlshrouqSchool.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Posts.Queries
{
    public record GetPostbyIdQuery(int Id):IRequest<PostDto>;

    public class GetPostbyIdQueryHandler(IPostRepository postRepository) : IRequestHandler<GetPostbyIdQuery, PostDto>
    {
        public async Task<PostDto> Handle(GetPostbyIdQuery request, CancellationToken cancellationToken)
        {
            var post =  await  postRepository.GetByIdAsync(request.Id);
           // if (post is null) throw new NotFoundException($"Post with Id {request.Id} not found");
            return new PostDto(post.Id, post.Title, post.Content, post.CreatedAtUtc);
        }
    }
}
