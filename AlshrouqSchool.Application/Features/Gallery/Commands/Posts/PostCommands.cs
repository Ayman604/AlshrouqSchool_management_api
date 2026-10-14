using AlshrouqSchool.Domain.Contracts;
using AlshrouqSchool.Domain.Entities.MediaAndContentModule;
using AlshrouqSchool.Shared.DTOs.Gallery.Posts;
using AutoMapper; using MediatR;
namespace AlshrouqSchool.Application.Features.Gallery.Commands.Posts;
public sealed record CreatePostCommand(CreatePostDto Dto) : IRequest<PostDto>;
public sealed record UpdatePostCommand(int Id, UpdatePostDto Dto) : IRequest<PostDto>;
public sealed record DeletePostCommand(int Id) : IRequest<bool>;
public sealed record PublishPostCommand(int Id) : IRequest<bool>;
public sealed record UnpublishPostCommand(int Id) : IRequest<bool>;
public sealed class CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreatePostCommand, PostDto>
{ public async Task<PostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken) { var repo=unitOfWork.GetRepository<Post,int>(); var slug=request.Dto.Slug.Trim().ToLowerInvariant(); if ((await repo.GetAllAsync()).Any(p=>!p.IsDeleted && p.Slug==slug)) throw new InvalidOperationException("A post with this slug already exists."); var entity=mapper.Map<Post>(request.Dto); entity.Slug=slug; await repo.AddAsync(entity); await unitOfWork.SAveChangesAsync(cancellationToken); return mapper.Map<PostDto>(entity); } }
public sealed class UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdatePostCommand, PostDto>
{ public async Task<PostDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken) { var repo=unitOfWork.GetRepository<Post,int>(); var entity=await repo.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Post was not found."); if (entity.IsDeleted) throw new KeyNotFoundException("Post was not found."); var slug=request.Dto.Slug.Trim().ToLowerInvariant(); if ((await repo.GetAllAsync()).Any(p=>p.Id!=entity.Id && !p.IsDeleted && p.Slug==slug)) throw new InvalidOperationException("A post with this slug already exists."); mapper.Map(request.Dto,entity); entity.Slug=slug; repo.Update(entity); await unitOfWork.SAveChangesAsync(cancellationToken); return mapper.Map<PostDto>(entity); } }
public sealed class DeletePostCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePostCommand, bool>
{ public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken) { var repo=unitOfWork.GetRepository<Post,int>(); var entity=await repo.GetByIdAsync(request.Id); if (entity is null || entity.IsDeleted) return false; entity.IsDeleted=true; entity.DeletedAtUtc=DateTime.UtcNow; repo.Update(entity); await unitOfWork.SAveChangesAsync(cancellationToken); return true; } }
public sealed class PublishPostCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<PublishPostCommand, bool>
{ public async Task<bool> Handle(PublishPostCommand request, CancellationToken cancellationToken) { var repo=unitOfWork.GetRepository<Post,int>(); var entity=await repo.GetByIdAsync(request.Id); if (entity is null || entity.IsDeleted) return false; entity.IsPublished=true; entity.PublishedAtUtc=DateTime.UtcNow; repo.Update(entity); await unitOfWork.SAveChangesAsync(cancellationToken); return true; } }
public sealed class UnpublishPostCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UnpublishPostCommand, bool>
{ public async Task<bool> Handle(UnpublishPostCommand request, CancellationToken cancellationToken) { var repo=unitOfWork.GetRepository<Post,int>(); var entity=await repo.GetByIdAsync(request.Id); if (entity is null || entity.IsDeleted) return false; entity.IsPublished=false; entity.PublishedAtUtc=null; repo.Update(entity); await unitOfWork.SAveChangesAsync(cancellationToken); return true; } }