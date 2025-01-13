using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectItemViewModel>>
{
    private readonly IProjectRepository _repository;

    public GetProjectByIdHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<ProjectItemViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetDetailsById(request.Id);

        if (project is null)
        {
            return ResultViewModel<ProjectItemViewModel>.Error("Projeto não existe.");
        }

        var model = ProjectItemViewModel.FromEntity(project);

        return ResultViewModel<ProjectItemViewModel>.Success(model);
    }
}