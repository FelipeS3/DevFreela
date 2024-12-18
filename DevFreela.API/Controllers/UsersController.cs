using DevFreela.Application.Commands.InsertUser;
using DevFreela.Application.Commands.InsertUserSkill;
using DevFreela.Application.Models;
using DevFreela.Application.Queries.GetUsersbyId;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly IMediator _mediator;
        public UsersController(DevFreelaDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUsersByIdQuery(id));

            if (!user.IsSuccess)
            {
                return NotFound();
            }

            return Ok(user);
        }
        //POST api/user
        [HttpPost("post-user")]
        public async Task<IActionResult> PostUser(InsertUserCommand command)
        {
            //var user = new User(model.FullName, model.Email, model.BirthDate);

            var user = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = user.Data }, command);
        }

        [HttpPost("{id}/post-skills")]
        public async Task<IActionResult> PostSkills(int id, InsertUserSkillCommand command)
        {
            //var userSkills = model.SkillIds.Select(s => new UserSkill(id, s)).ToList();

            var userSkills = await _mediator.Send(command);

            if (!userSkills.IsSuccess)
            {
                return NotFound("Usuario não encontrado");
            }

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id,IFormFile file)
        {
            var description = $"File: {file.FileName} Size: {file.Length}";

            return Ok(description);
        }
    }
}
