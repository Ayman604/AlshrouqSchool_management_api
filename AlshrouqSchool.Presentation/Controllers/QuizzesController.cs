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
    public class QuizzesController(ISender sender) : ControllerBase
    {
        [HttpGet("lesson/{lessonId:int}")]
        public async Task<IActionResult> GetByLesson(int lessonId)
            => Ok(await sender.Send(new GetQuizzesByLessonQuery(lessonId))); 

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuizDto dto)
            => Ok(await sender.Send(new CreateQuizCommand(dto))); 

        [HttpPost("questions")]
        public async Task<IActionResult> AddQuestion([FromBody] CreateQuestionDto dto)
            => Ok(await sender.Send(new CreateQuestionCommand(dto))); 

        [HttpPost("start-attempt")]
        public async Task<IActionResult> StartAttempt([FromBody] StartQuizAttemptDto dto)
            => Ok(await sender.Send(new StartQuizAttemptCommand(dto))); 

        [HttpPost("submit-attempt")]
        public async Task<IActionResult> SubmitAttempt([FromBody] SubmitQuizAttemptDto dto)
            => Ok(await sender.Send(new SubmitQuizAttemptCommand(dto))); 
    }
}
