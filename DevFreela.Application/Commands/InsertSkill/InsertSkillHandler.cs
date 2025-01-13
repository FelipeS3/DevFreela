using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertSkill;

public class InsertSkillHandler : IRequestHandler<InsertSkillCommand, ResultViewModel<int>>
{
    private readonly ISkillRepository _repository;
    public InsertSkillHandler(ISkillRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = request.ToEntity();

        await _repository.AddSkill(skill);

        return ResultViewModel<int>.Success(skill.Id);
    }
}