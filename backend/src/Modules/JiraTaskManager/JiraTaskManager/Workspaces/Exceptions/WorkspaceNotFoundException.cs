namespace JiraTaskManager.Workspaces.Exceptions;

public class WorkspaceNotFoundException(Guid workspaceId)
  : NotFoundException("Workspace", workspaceId)
{

}
