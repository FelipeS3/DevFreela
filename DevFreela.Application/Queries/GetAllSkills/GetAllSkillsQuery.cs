using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQuery : IRequest<ResultViewModel<List<SkillViewModel>>>
{
    public string Description { get; set; }
}