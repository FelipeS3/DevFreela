using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface ISkillRepository
{
    Task<List<Skill>> GetAllSkills();
    Task<int> AddSkill(Skill skill);
}