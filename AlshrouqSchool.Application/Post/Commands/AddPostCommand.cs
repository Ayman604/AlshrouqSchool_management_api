using AlshrouqSchool.Application.Posts.DTOs;
using AlshrouqSchool.Core.Entities;
using AlshrouqSchool.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlshrouqSchool.Application.Posts.Commands
{
    public record AddPostCommand(CreatePostDto PostDto) :IRequest<PostDto>;


    public class AddPostCommandHandler(IPostRepository postRepository) : IRequestHandler<AddPostCommand, PostDto>
    {
        public async Task<PostDto> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            // 1. Map DTO to Entity
            var entity = new Post
            {
                Title = request.PostDto.Title,
                Content = request.PostDto.Content
            };
            // 2. Add & Save
            var createdEntity = await postRepository.AddAsync(entity);
            await postRepository.save();

            // 3. Map Entity to DTO
            return new PostDto(createdEntity.Id, createdEntity.Title, createdEntity.Content, createdEntity.CreatedAtUtc);
        }
    }
}
