using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertComment;

public class InsertCommentCommand : IRequest<ResultViewModel>
{
    public int IdProject { get; set; }
    public int IdUser { get; set; }
    public string Content { get; set; }
}