using AlshrouqSchool.Application.Academic.DTOs;
using AlshrouqSchool.Application.Academic.Queries;
using AlshrouqSchool.Application.Academic.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlshrouqSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeLevelsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllGradeLevelsQuery())); 

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await sender.Send(new GetGradeLevelByIdQuery(id)); 
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGradeLevelDto dto)
        {
            var result = await sender.Send(new CreateGradeLevelCommand(dto)); 
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
