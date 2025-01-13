using MediatR;

namespace DevFreela.Application.Notification.ProjectCreated;

public class ProjectCreatedNotification : INotification
{
    public ProjectCreatedNotification(int id,string title,decimal totalCost)
    {
        Id = id;
        Title = title;
        TotalCost = totalCost;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public decimal TotalCost { get; private set; }
}