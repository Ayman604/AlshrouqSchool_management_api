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
    public class LiveSessionsController(ISender sender) : ControllerBase
    {
        [HttpGet("section/{sectionId:int}")]
        public async Task<IActionResult> GetBySection(int sectionId)
            => Ok(await sender.Send(new GetLiveSessionsBySectionQuery(sectionId))); 

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLiveSessionDto dto)
            => Ok(await sender.Send(new CreateLiveSessionCommand(dto))); 
    }
}
