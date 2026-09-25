using AlshrouqSchool.Application.Learning.Commands;
using AlshrouqSchool.Application.Learning.DTOs;
using AlshrouqSchool.Application.Learning.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlshrouqSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController(ISender sender) : ControllerBase
    {
        [HttpGet("subject/{subjectId:int}")]
        public async Task<IActionResult> GetBySubject(int subjectId)
            => Ok(await sender.Send(new GetLessonsBySubjectQuery(subjectId))); 

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await sender.Send(new GetLessonByIdQuery(id)); 
            return res == null ? NotFound() : Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLessonDto dto)
            => Ok(await sender.Send(new CreateLessonCommand(dto))); 
    }
}
