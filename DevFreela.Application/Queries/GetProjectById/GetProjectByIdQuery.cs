using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ResultViewModel<ProjectItemViewModel>>
{
    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}