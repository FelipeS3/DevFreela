using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
{
    private readonly IProjectRepository _repository;

    public GetAllProjectsHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        //var skip = request.Page * request.Size;

        var project = await _repository.GetAll();

        var model = project.Select(ProjectItemViewModel.FromEntity).ToList();

        return ResultViewModel<List<ProjectItemViewModel>>.Success(model);  
    }
}