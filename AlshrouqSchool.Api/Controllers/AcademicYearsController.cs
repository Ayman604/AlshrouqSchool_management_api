using AlshrouqSchool.Application.Academic.DTOs;
using AlshrouqSchool.Application.Academic.Queries;
using AlshrouqSchool.Application.Academic.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
namespace AlshrouqSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicYearsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllAcademicYearsQuery())); 

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await sender.Send(new GetAcademicYearByIdQuery(id)); 
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAcademicYearDto dto)
        {
            var result = await sender.Send(new CreateAcademicYearCommand(dto)); 
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAcademicYearDto dto)
        {
            var success = await sender.Send(new UpdateAcademicYearCommand(id, dto)); 
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await sender.Send(new DeleteAcademicYearCommand(id)); 
            return success ? NoContent() : NotFound();
        }
    }
}
