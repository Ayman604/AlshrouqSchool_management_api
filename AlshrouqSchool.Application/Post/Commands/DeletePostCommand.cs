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
    public record DeletePostCommand(int Id):IRequest<bool>;

    public class DeletePostCommandHandler(IPostRepository postRepository) : IRequestHandler<DeletePostCommand, bool>
    {
        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            return await postRepository.DeleteAsync(request.Id);
        }
    }
}
