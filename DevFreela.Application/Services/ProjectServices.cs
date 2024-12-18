using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services;

public class ProjectServices : IProjectServices
{
    private readonly DevFreelaDbContext _context;
    public ProjectServices(DevFreelaDbContext context)
    {
        _context = context;
    }
    public ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "", int page = 0, int size = 3)
    {
        var project = _context.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .Where(p => !p.IsDeleted && (search == "" || p.Title.Contains(search) || p.Description.Contains(search)))
            .Skip(page * size)
            .Take(size)
            .ToList();

        var model = project.Select(ProjectItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
    }

    public ResultViewModel<ProjectViewModel> GetById(int id)
    {
        var project = _context.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .Include(p => p.Comments)
            .SingleOrDefault(p => p.Id == id);

        if (project is null)
        {
            return ResultViewModel<ProjectViewModel>.Error("Projeto não existe.");
        }

        var model = ProjectViewModel.FromEntity(project);

        return ResultViewModel<ProjectViewModel>.Success(model);
    }

    public ResultViewModel<int> Insert(CreateProjectInputModel model)
    {
        var project = model.ToEntity();

        _context.Projects.Add(project);
        _context.SaveChanges();

        return ResultViewModel<int>.Success(project.Id);
    }

    public ResultViewModel Start(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project is null)
        {
            return ResultViewModel.Error("Projeto não encontrado.");
        }

        project.Start();

        _context.Projects.Update(project);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }

    public ResultViewModel Complete(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);
        if (project is null)
        {
            return ResultViewModel.Error("Projeto não encontrado.");
        }

        project.Complete();
        _context.Projects.Update(project);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }

    public ResultViewModel Delete(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);
        if (project is null)
        {
            return ResultViewModel.Error("Projeto não encontrado.");
        }

        project.SetAsDeleted();
        _context.Projects.Update(project);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }

    public ResultViewModel Update(UpdateProjectInputModel model)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == model.IdProject);

        if (project is null)
        {
            return ResultViewModel.Error("Este projeto não existe");
        }
        project.Update(model.Title, model.Description, model.TotalCost);

        _context.Projects.Update(project);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }

    public ResultViewModel InsertComments(int id, CreateProjectCommentInputModel model)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);
        if (project is null)
        {
            return ResultViewModel.Error("Projeto não encontrado.");
        }

        var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);

        _context.ProjectComments.Add(comment);
        _context.SaveChanges();

        return ResultViewModel.Success();
    }
}