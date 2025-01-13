using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkill;

public class InsertUserSkillCommand : IRequest<ResultViewModel<int>>
{
    public int IdUser { get; set; }
    public int IdSkill { get; set; }
    public UserSkill ToEntity()
        => new(IdSkill,IdUser);
}