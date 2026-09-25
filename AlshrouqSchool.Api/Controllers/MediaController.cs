using AlshrouqSchool.Application.ContentAndLive.Commands;
using AlshrouqSchool.Application.ContentAndLive.DTOs;
using AlshrouqSchool.Application.ContentAndLive.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlshrouqSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController(ISender sender) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await sender.Send(new GetMediaQuery(id)); 
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] CreateMediaDto dto)
            => Ok(await sender.Send(new UploadMediaCommand(dto)));
    }
}
