using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DevFreelaDbContext _context;

    public SkillRepository(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Skill>> GetAllSkills()
    {
        var skills = await _context.Skills.ToListAsync();

        return skills;
    }

    public async Task<int> AddSkill(Skill skill)
    {
        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();

        return skill.Id;
    }
}