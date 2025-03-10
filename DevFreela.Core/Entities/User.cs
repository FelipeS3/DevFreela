namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    public User(string fullname, string email, DateTime birthDate, string password, string role) : base()
    {
        Fullname = fullname;
        Email = email;
        BirthDate = birthDate;
        Active = true;
        Password = password;
        Role = role;

        Skills = [];
        OwnerProjects = [];
        FreelanceProjects = [];
        Comments = [];
    }
    public string Fullname { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Active { get; private set; }
    public string Password {get; private set; }
    public string Role { get; private set; }
    public List<UserSkill> Skills { get; private set; }
    public List<ProjectComment> Comments { get; private set; }
    public List<Project> OwnerProjects { get; private set; }
    public List<Project> FreelanceProjects { get; private set; }
}