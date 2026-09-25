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
    public record UpdatePostCommand(int Id , UpdatePostDto PostDto) : IRequest<bool>;
    public class UpdatePostCommandHandler(IPostRepository postRepository) : IRequestHandler<UpdatePostCommand, bool>
    {
        public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = new Post
            {
                Id = request.Id,
                Title = request.PostDto.Title,
                Content = request.PostDto.Content
            };

            var updatedEntity = await postRepository.UpdateAsync(request.Id, entityToUpdate);
            if (updatedEntity == null) return false;

            await postRepository.save(); 
            return true;
        }
    }
}
