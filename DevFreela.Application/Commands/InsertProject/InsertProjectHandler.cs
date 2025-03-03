using DevFreela.Application.Models;
using DevFreela.Application.Notification.ProjectCreated;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject;

public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
{
    private readonly IMediator _mediator;
    private readonly IProjectRepository _repository;

    public InsertProjectHandler (IMediator mediator, IProjectRepository repository)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
    {
        var project = request.ToEntity();

        var id = await _repository.AddProject(project);

        var projectCreated = new ProjectCreatedNotification(project.Id,project.Title,project.TotalCost);

        await _mediator.Publish(projectCreated);

        return ResultViewModel<int>.Success(id);
    }
}