
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly FreelanceTotalCostConfig _config;
        public ProjectsController(IOptions<FreelanceTotalCostConfig> options,
                                                DevFreelaDbContext context)
        {
            _config = options.Value;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string search = "", int page = 0, int size = 3)
        {
            var project = _context.Projects
                .Include(p=>p.Client)
                .Include(p=>p.Freelancer)
                .Where(p => !p.IsDeleted && (search == "" || p.Title.Contains(search) || p.Description.Contains(search)))
                .Skip(page * size)
                .Take(size)
                .ToList();

            var model = project.Select(ProjectItemViewModel.FromEntity).ToList();

            return Ok(model); 
        }

        //GET api/projects/1234
        [HttpGet("{id}")] 
        public IActionResult GetById(int id)
        {
            var project = _context.Projects
                .Include(p=>p.Client)
                .Include(p=>p.Freelancer)
                .Include(p=>p.Comments)
                .SingleOrDefault(p => p.Id == id);

            var model = ProjectViewModel.FromEntity(project);
            return Ok(model);
        }
        //POST api/project
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var project = model.ToEntity();

            _context.Projects.Add(project);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }
        //PUT api/project/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }
            project.Update(model.Title,model.Description,model.TotalCost);
            _context.Projects.Update(project);
            _context.SaveChanges();
            return Ok(project);
            

        }

        //DELETE api/project/1234
        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            } 

            project.SetAsDeleted();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return Ok();
        }
        //PUT api/project/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }
            project.Start();

            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }
        //PUT api/project/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }

            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChanges();
             
            return NoContent();
        }

        //POST api/project/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComments(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return NotFound();
            }

            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
            _context.ProjectComments.Add(comment);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
