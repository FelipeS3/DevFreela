using DevFreela.Core.Entities;

namespace DevFreela.Application.Models;

public class UserViewModel
{
    public UserViewModel(string fullname, string email, DateTime birthDate, List<string> skills)
    {
        Fullname = fullname;
        Email = email;
        Skills = skills;
    }

    public string Fullname { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public List<string> Skills { get; private set; }


    public static UserViewModel FromEntity(User user)
    {
        var skills = user.Skills.Select(u => u.Skill.Description).ToList();

        return new UserViewModel(user.Fullname, user.Email, user.BirthDate, skills);
    }

}