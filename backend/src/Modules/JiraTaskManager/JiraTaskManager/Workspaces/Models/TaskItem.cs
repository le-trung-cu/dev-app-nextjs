using JiraTaskManager.Workspaces.ValueObjects;
using Shared.DDD;

namespace JiraTaskManager.Workspaces.Models;

public class TaskItem : Entity<Guid>
{
  public string Name { get; private set; } = default!;
  public TaskItemStatus Status { get; private set; }
  public DateTime? EndDate { get; private set; }
  public string? Description { get; private set; }
  public Guid WorkspaceId { get; private set; }
  public Guid? ProjectId { get; private set; }
  public Project? Project { get; private set; }
  public Guid? AssigneeId { get; private set; }
  public Member? Assignee { get; private set; }
  public Priority Priority { get; private set; }
  public int Position { get; private set; }

  internal TaskItem(Guid workspaceId, Guid? projectId, Guid? assigneeId, string name, TaskItemStatus status, Priority priority, DateTime? endDate, string? description)
  {
    WorkspaceId = workspaceId;
    ProjectId = projectId;
    AssigneeId = assigneeId;
    Name = name;
    Status = status;
    Priority = priority;
    EndDate = endDate;
    Description = description;
  }

  public void Update(Guid? projectId, Guid? assigneeId, string name, TaskItemStatus status, Priority priority, DateTime? endDate)
  {
    ProjectId = projectId;
    AssigneeId = assigneeId;
    Name = name;
    Status = status;
    Priority = priority;
    EndDate = endDate;
  }

  public void Update(string description)
  {
    Description = description;
  }

  public void UpdateStatus(TaskItemStatus status)
  {
    Status = status;
  }

  public void UpdatePosition(int position)
  {
    Position = position > 1_000_000 ? 1_000_000 : position;
  }
}
