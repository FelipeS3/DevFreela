using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DevFreela.Application.Commands.InsertProject;

public class ValidateInsertProjectCommandBehavior : IPipelineBehavior<InsertProjectCommand,ResultViewModel<int>>
{
    private readonly DevFreelaDbContext _context;

    public ValidateInsertProjectCommandBehavior(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
    {
        var clientExists = _context.Users.Any(u=> u.Id == request.IdClient);

        var freelanceExists = _context.Users.Any(f => f.Id == request.IdFreelancer);

        if (!clientExists || !freelanceExists)
        {
            return ResultViewModel<int>.Error("Cliente ou Freelancer inválidos!");
        }

        return await next();
    }
}