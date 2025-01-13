using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DevFreelaDbContext _context;

    public UserRepository(DevFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetUserById(int id)
    {
        var user = await _context.Users
            .Include(u=> u.OwnerProjects)
            .Include(u=>u.FreelanceProjects)
            .SingleOrDefaultAsync(u => u.Id == id);

        return user;
    }

    public async Task<int> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<int> PostUserSkills(UserSkill skills)
    {
        await _context.UserSkills.AddAsync(skills);
        await _context.SaveChangesAsync();
        return skills.Id;
    }
    public async Task<User?> GetById(int id)
    {
        return await _context.Users
            .SingleOrDefaultAsync(p => p.Id == id);
    }
}