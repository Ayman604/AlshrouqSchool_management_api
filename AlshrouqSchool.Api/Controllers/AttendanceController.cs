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
    public class AttendanceController(ISender sender) : ControllerBase
    {
        [HttpPost("session")]
        public async Task<IActionResult> CreateSession([FromBody] CreateAttendanceSessionDto dto)
            => Ok(await sender.Send(new CreateAttendanceSessionCommand(dto))); 

        [HttpPost("mark")]
        public async Task<IActionResult> SaveRecords([FromBody] SaveAttendanceRecordListDto dto)
        {
            var success = await sender.Send(new SaveAttendanceRecordsCommand(dto)); 
            return success ? Ok() : BadRequest();
        }

        [HttpGet("session/{sessionId:int}")]
        public async Task<IActionResult> GetBySession(int sessionId)
            => Ok(await sender.Send(new GetAttendanceBySessionQuery(sessionId)));
    }
}
