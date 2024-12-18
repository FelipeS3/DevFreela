using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkill;

public class InsertUserSkillCommand : IRequest<ResultViewModel>
{
    public int[] SkillIds { get; set; }
    public int Id { get; set; }
}