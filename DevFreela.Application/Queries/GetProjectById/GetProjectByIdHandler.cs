using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectItemViewModel>>
{
    private readonly DevFreelaDbContext _context;

    public GetProjectByIdHandler(DevFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<ProjectItemViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .Include(p => p.Comments)
            .SingleOrDefaultAsync(p => p.Id == request.Id);

        if (project is null)
        {
            return ResultViewModel<ProjectItemViewModel>.Error("Projeto não existe.");
        }

        var model = ProjectItemViewModel.FromEntity(project);

        return ResultViewModel<ProjectItemViewModel>.Success(model);
    }
}