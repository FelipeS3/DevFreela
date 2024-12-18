
using DevFreela.Application.Commands.CompleteProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.InsertComment;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Models;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectServices _services;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectServices services, IMediator mediator)
        {
            _mediator = mediator;
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = "", int page = 0, int size = 3)
        {
            //var result = _services.GetAll(search, page, size);

            var query = new GetAllProjectsQuery(search, page, size);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        //GET api/projects/1234
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            // var result = _services.GetById(id);

            var result = await _mediator.Send(new GetProjectByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest("Projeto não encontrado!");
            }

            return Ok(result);
        }
        //POST api/project
        [HttpPost]
        public async Task<IActionResult> Post(InsertProjectCommand command)
        {
            // var result = _services.Insert(model);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
        //PUT api/project/1234
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProjectCommand command)
        {
            //var result = _services.Update(model);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        //DELETE api/project/1234
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand(id));

            if (!result.IsSuccess) 
            {
                return NotFound(result.Message);
            }
            return Ok();
        }
        //PUT api/project/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            //var result = _services.Start(id);
            var result = await _mediator.Send(new StartProjectCommand(id));

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return NoContent();
        }
        //PUT api/project/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            //var result = _services.Complete(id);

            var result = await _mediator.Send(new CompleteProjectCommand(id));

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }

        //POST api/project/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComments(int id, InsertCommentCommand command)
        {
            //var result = _services.InsertComments(id, command);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }

}
