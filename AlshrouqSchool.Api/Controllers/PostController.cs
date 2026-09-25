using AlshrouqSchool.Application.Posts.Commands;
using AlshrouqSchool.Application.Posts.DTOs;
using AlshrouqSchool.Application.Posts.Queries;
using AlshrouqSchool.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlshrouqSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(ISender sender) : ControllerBase
    {
        // GET: api/<PostController>
        [HttpGet]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            var result = await sender.Send(new GetAllPostsQuery());
            return Ok(result);
        }

        // GET api/<PostController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPostByIdAsync([FromRoute] int Id)
        {
            var result = await sender.Send(new GetPostbyIdQuery(Id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<PostController>
        [HttpPost("")]
        public async Task<IActionResult> AddPostAsync([FromBody] CreatePostDto dto)
        {
            var result = await sender.Send(new AddPostCommand(dto));
            return CreatedAtAction(nameof(GetPostByIdAsync), new { id = result.Id }, result);
            // return Ok(result);
        }

        // PUT api/<PostController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatePostAsync(int Id, [FromBody] UpdatePostDto dto)
        {
            var result = await sender.Send(new UpdatePostCommand(Id, dto));
            if (!result) return NotFound();
            return NoContent();
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePostAsync(int Id)
        {
            var result = await sender.Send(new DeletePostCommand(Id));
            if (!result) return NotFound();
            return NoContent();

            // return Ok(result);
        }
    }
}
