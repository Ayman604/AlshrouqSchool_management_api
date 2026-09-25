using AlshrouqSchool.Application.People.Commands;
using AlshrouqSchool.Application.People.DTOs;
using AlshrouqSchool.Application.People.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlshrouqSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllTeachersQuery())); 

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await sender.Send(new GetTeacherByIdQuery(id)); 
            return res == null ? NotFound() : Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDto dto)
            => Ok(await sender.Send(new CreateTeacherCommand(dto))); 

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDto dto)
        {
            var success = await sender.Send(new UpdateTeacherCommand(id, dto)); 
            return success ? NoContent() : NotFound();
        }
    }
}
