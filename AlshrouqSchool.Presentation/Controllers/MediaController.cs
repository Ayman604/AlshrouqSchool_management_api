using AlshrouqSchool.Application.Features.Gallery.Commands.Media; using AlshrouqSchool.Application.Features.Gallery.Queries.Media; using AlshrouqSchool.Shared.DTOs.Gallery.Common; using AlshrouqSchool.Shared.DTOs.Gallery.Media; using MediatR; using Microsoft.AspNetCore.Mvc;
namespace AlshrouqSchool.Api.Controllers;
[ApiController][Route("api/[controller]")] public sealed class MediaController(IMediator mediator):ControllerBase
{
 [HttpGet] public async Task<ActionResult<PagedResult<MediaDto>>> GetAll([FromQuery]MediaQueryParameters parameters,CancellationToken cancellationToken)=>Ok(await mediator.Send(new GetGalleryMediaQuery(parameters),cancellationToken));
 [HttpGet("{id:int}")] public async Task<ActionResult<MediaDto>> GetById([FromRoute]int id,CancellationToken cancellationToken){var result=await mediator.Send(new GetMediaByIdQuery(id),cancellationToken);return result is null?NotFound():Ok(result);}
 [HttpPost] public async Task<ActionResult<MediaDto>> Create([FromBody]CreateMediaDto dto,CancellationToken cancellationToken){var result=await mediator.Send(new CreateMediaCommand(dto),cancellationToken);return CreatedAtAction(nameof(GetById),new{id=result.Id},result);}
 [HttpPut("{id:int}")] public async Task<ActionResult<MediaDto>> Update([FromRoute]int id,[FromBody]UpdateMediaDto dto,CancellationToken cancellationToken)=>Ok(await mediator.Send(new UpdateMediaCommand(id,dto),cancellationToken));
 [HttpDelete("{id:int}")] public async Task<ActionResult<bool>> Delete([FromRoute]int id,CancellationToken cancellationToken)=>await mediator.Send(new DeleteMediaCommand(id),cancellationToken)?NoContent():NotFound();
}