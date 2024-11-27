using DevFreela.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Persistence;

public class DevFreelaDbContext : DbContext
{
    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<ProjectComment> ProjectComments { get; set; }
    public DbSet<Skill> Skill { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Skill>(e =>
        {
            e.HasKey(s => s.Id);
        });

        builder.Entity<UserSkill>(e =>
        {
            e.HasKey(us => us.Id);

            e.HasOne(u => u.Skill)
                .WithMany(u => UserSkills)
                .HasForeignKey(u => u.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<ProjectComment>(e =>
        {
            e.HasKey(c => c.Id);

            e.HasOne(c=>c.Project)
                .WithMany(p=>p.Comments)
                .HasForeignKey(c=>c.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<User>(e =>
        {
            e.HasKey(u => u.Id);

            e.HasMany(u=>u.Skills)
                .WithOne(us=>us.User)
                .HasForeignKey(us=>us.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        builder.Entity<Project>(e =>
        {
            e.HasKey(p => p.Id);

            e.HasOne(p=>p.Freelancer)
                .WithMany(f=>f.FreelanceProjects)
                .HasForeignKey(p=>p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(p=>p.Client)
                .WithMany(c=>c.OwnerProjects)
                .HasForeignKey(p=>p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        });

        base.OnModelCreating(builder);
    }
}