namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    public User(string fullname, string email, DateTime birthDate) : base()
    {
        Fullname = fullname;
        Email = email;
        BirthDate = birthDate;
        Active = true;

        Skills = [];
        OwnerProjects = [];
        FreelanceProjects = [];
        Comments = [];
    }
    public string Fullname { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Active { get; private set; }
    public List<UserSkill> Skills { get; private set; }
    public List<ProjectComment> Comments { get; private set; }
    public List<Project> OwnerProjects { get; private set; }
    public List<Project> FreelanceProjects { get; private set; }
}