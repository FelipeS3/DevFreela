using System.Data;
using DevFreela.Core.Enum;

namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public const string INVALID_STATE_MESSAGE = "Project is not created";
    public const string INVALID_CANCELSTATE_MESSAGE = "Project is not in progress";
    protected Project()
    {

    }
    public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost) : base()
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;

        Status = ProjectStatusEnum.Created;
        Comments = [];
    }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdClient { get; private set; }
    public User Client { get; private set; }
    public int IdFreelancer { get; private set; }
    public User Freelancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public void Cancel()
    {
        if (Status != ProjectStatusEnum.InProgress)
        {
            throw new InvalidOperationException(INVALID_CANCELSTATE_MESSAGE);
        }
        Status = ProjectStatusEnum.Cancelled;
    }

    public void Start()
    {
        if (Status != ProjectStatusEnum.Created)
        {
            throw new InvalidOperationException(INVALID_STATE_MESSAGE);
        }
        Status = ProjectStatusEnum.InProgress;
        StartedAt = DateTime.Now;
    }

    public void Complete()
    {
        if (Status == ProjectStatusEnum.PaymantPending || Status == ProjectStatusEnum.Completed)
        {
            Status = ProjectStatusEnum.Completed;
            CompletedAt = DateTime.Now;
        }
    }

    public void SetPaymantsPending()
    {
        if (Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.PaymantPending;
        }
    }

    public void Update(string title, string description, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}