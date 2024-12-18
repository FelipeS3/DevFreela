using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.StartProject;

public class StartProjectCommand : IRequest<ResultViewModel>
{
    public StartProjectCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}