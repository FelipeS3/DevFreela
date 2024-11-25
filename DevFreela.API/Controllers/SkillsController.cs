using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        //GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
        //POST api/skills
        [HttpPost]
        public IActionResult Post(CreatedSkillInputModel model)
        {
            return Created();
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
