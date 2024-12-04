using DevFreela.API.Entities;

namespace DevFreela.API.Models;

public class ProjectItemViewModel
{
    public ProjectItemViewModel(int id ,string title, string clientName, string freelancerName)
    {
        Id = id;
        Title = title;
        ClientName = clientName;
        FreelancerName = freelancerName;
    }
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string ClientName { get; private set; }
    public string FreelancerName { get; private set; }
    public decimal TotalCost { get; private set; }


    public static ProjectItemViewModel FromEntity(Project project) => new(project.Id, project.Title,
        project.Client.Fullname, project.Freelancer.Fullname);
}