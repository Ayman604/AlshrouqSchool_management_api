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
    public class StudentController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllStudentsQuery())); 

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
            => Ok(await sender.Send(new CreateStudentCommand(dto))); 

        [HttpPost("enroll")]
        public async Task<IActionResult> Enroll([FromBody] CreateStudentEnrollmentDto dto)
            => Ok(await sender.Send(new EnrollStudentCommand(dto))); 

        [HttpPost("link-parent")]
        public async Task<IActionResult> LinkParent([FromBody] CreateStudentParentDto dto)
            => Ok(await sender.Send(new LinkStudentParentCommand(dto)));
    }
}
