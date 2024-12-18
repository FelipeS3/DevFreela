using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetUsersbyId;

public class GetUsersByIdHandler : IRequestHandler<GetUsersByIdQuery, ResultViewModel<UserViewModel>>
{
    private readonly DevFreelaDbContext _context;

    public GetUsersByIdHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<UserViewModel>> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.Skills)
            .ThenInclude(u => u.Skill)
            .FirstOrDefaultAsync(u => u.Id == request.Id);

        if (user is null)
        {
            return ResultViewModel<UserViewModel>.Error("Usuario não existe");
        }

        var model = UserViewModel.FromEntity(user);

        return ResultViewModel<UserViewModel>.Success(model);
    }
}