using DevFreela.Application.Commands.InsertUser;
using DevFreela.Application.Commands.InsertUserSkill;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Models;
using DevFreela.Application.Queries.GetUsersbyId;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;
        public UsersController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
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
        [AllowAnonymous]
        public async Task<IActionResult> PostUser(InsertUserCommand command)
        {
            //var user = new User(model.FullName, model.Email, model.BirthDate, model.Password, model.Role);

            command.Password = _authService.ComputeHash(command.Password);

            var user = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = user.Data }, command);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("E-mail e senha são obrigatórios.");
            }

            var command = new LoginUserCommand(model.Email, model.Password);
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(new { Token = result.Data }) : BadRequest(result.Message);
        }


        [HttpPost("{id}/post-skills")]
        public async Task<IActionResult> PostUserSkills(int id, InsertUserSkillCommand command)
        {
            //var userSkills = model.SkillIds.Select(s => new UserSkill(id, s)).ToList();

            var userSkills = await _mediator.Send(command);

            if (!userSkills.IsSuccess)
            {
                return NotFound("Usuário não encontrado");
            }

            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id,IFormFile file)
        {
            var description = $"File: {file.FileName} Size: {file.Length}";

            return Ok(description);
        }

        [HttpGet("test")]
        public IActionResult TesteToken()
        {
            var token = _authService.GenerateToken("felipexy50@gmail.com", "cliente");
            return Ok(new {Token = token});
        }
    }
}
