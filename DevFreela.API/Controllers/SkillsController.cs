using DevFreela.Application.Commands.InsertSkill;
using DevFreela.Application.Models;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DevFreelaDbContext _context;
        public SkillsController(DevFreelaDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        //GET api/skills
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = await _mediator.Send(new GetAllSkillsQuery());

            return Ok(query);
        }
        //POST api/skills
        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command)
        {
            var skill = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetAll), new { id = skill.Data }, skill.Data);
        }

    }
}
