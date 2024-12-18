using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetUsersbyId;

public class GetUsersByIdQuery : IRequest<ResultViewModel<UserViewModel>>
{
    public GetUsersByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}