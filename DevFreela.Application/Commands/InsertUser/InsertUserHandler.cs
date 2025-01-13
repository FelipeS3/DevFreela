using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertUser;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _repository;

    public InsertUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();

        await _repository.AddUser(user);

        return ResultViewModel<int>.Success(user.Id);
    }
}