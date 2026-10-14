using AlshrouqSchool.Application.Academic.Commands;
using AlshrouqSchool.Application.Academic.DTOs;
using AlshrouqSchool.Application.Academic.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlshrouqSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController(ISender sender) : ControllerBase
    {
        [HttpGet("grade-level/{gradeLevelId:int}")]
        public async Task<IActionResult> GetByGradeLevel(int gradeLevelId)
            => Ok(await sender.Send(new GetSectionsByGradeLevelQuery(gradeLevelId)));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSectionDto dto)
        {
            var result = await sender.Send(new CreateSectionCommand(dto)); 
            return Ok(result);
        }
    }
}
