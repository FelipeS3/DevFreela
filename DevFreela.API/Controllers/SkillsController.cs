using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public SkillsController(DevFreelaDbContext context)
        {
            _context = context;
        }
        //GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _context.Skills.ToList();

            return Ok(skills);
        }
        //POST api/skills
        [HttpPost]
        public IActionResult Post(CreatedSkillInputModel model)
        {
            var skill = new Skill(model.Description);

            _context.Add(skill);
            _context.SaveChanges();

            return NoContent();
        }
        //PUT api/skills
        [HttpPut("{id}/skills")]
        public IActionResult Put(int id)
        {
            return Ok();
        }
        //DELETE api/skills
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
