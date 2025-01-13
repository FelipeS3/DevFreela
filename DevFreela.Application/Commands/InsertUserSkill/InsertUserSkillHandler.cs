using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.InsertUserSkill;

public class InsertUserSkillHandler : IRequestHandler<InsertUserSkillCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _repository;

    public InsertUserSkillHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertUserSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = request.ToEntity();

        var userSkillId = await _repository.PostUserSkills(skill);

        return ResultViewModel<int>.Success(userSkillId);
    }
}