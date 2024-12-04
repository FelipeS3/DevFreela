using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
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
        private readonly IConfigService _configService;
        public ProjectsController(IOptions<FreelanceTotalCostConfig> options,
                                                IConfigService configService, 
                                                DevFreelaDbContext context)
        {
            _config = options.Value;
            _configService = configService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var project = _context.Projects
                .Include(p=>p.Client)
                .Include(p=>p.Freelancer)
                .Where(p => !p.IsDeleted).ToList();

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
            return Ok(project);
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
