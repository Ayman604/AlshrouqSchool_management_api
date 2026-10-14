using AlshrouqSchool.Application.Features.Gallery.Commands.PostMedia; using AlshrouqSchool.Application.Features.Gallery.Queries.Media; using AlshrouqSchool.Application.Features.Gallery.Queries.PostMedia; using AlshrouqSchool.Shared.DTOs.Gallery.Common; using AlshrouqSchool.Shared.DTOs.Gallery.Media; using AlshrouqSchool.Shared.DTOs.Gallery.PostMedia; using MediatR; using Microsoft.AspNetCore.Mvc;
namespace AlshrouqSchool.Api.Controllers;
[ApiController][Route("api/[controller]")] public sealed class GalleryController(IMediator mediator):ControllerBase
{
 [HttpGet] public async Task<ActionResult<PagedResult<MediaDto>>> GetAll([FromQuery]MediaQueryParameters parameters,CancellationToken cancellationToken)=>Ok(await mediator.Send(new GetGalleryMediaQuery(parameters),cancellationToken));
 [HttpGet("{id:int}")] public async Task<ActionResult<List<PostMediaDto>>> GetPostMedia([FromRoute]int id,CancellationToken cancellationToken)=>Ok(await mediator.Send(new GetPostMediaQuery(id),cancellationToken));
 [HttpPost("attach")] public async Task<ActionResult<PostMediaDto>> Attach([FromBody]AttachMediaToPostDto dto,CancellationToken cancellationToken)=>Ok(await mediator.Send(new AttachMediaToPostCommand(dto),cancellationToken));
 [HttpDelete("detach")] public async Task<ActionResult<bool>> Detach([FromBody]DetachMediaFromPostDto dto,CancellationToken cancellationToken)=>await mediator.Send(new DetachMediaFromPostCommand(dto),cancellationToken)?NoContent():NotFound();
 [HttpPut("reorder")] public async Task<ActionResult<bool>> Reorder([FromBody]ReorderPostMediaDto dto,CancellationToken cancellationToken)=>await mediator.Send(new ReorderPostMediaCommand(dto),cancellationToken)?Ok(true):NotFound();
}