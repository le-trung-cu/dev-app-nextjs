namespace SlackChat.Workspaces.Features.CreateChannel;

public record CreateChannelCommand
  (Guid WorkspaceId, string Name)
  : ICommand<CreateChannelResult>;

public record CreateChannelResult(bool IsSuccess, Guid WorkspaceId, Guid ChannelId);

public class CreateChannelHandler
  (WorkspaceDbContext dbContext)
  : ICommandHandler<CreateChannelCommand, CreateChannelResult>
{
  public async Task<CreateChannelResult> Handle(CreateChannelCommand command, CancellationToken cancellationToken)
  {
    var workspace = await dbContext.Workspaces
      .Where(x => x.Id == command.WorkspaceId)
      .Include(x => x.Channels)
      .FirstOrDefaultAsync(cancellationToken)
      ?? throw new WorkspaceNotFoundException(command.WorkspaceId);

    var channel = workspace.AddChannel(command.Name);
    await dbContext.SaveChangesAsync(cancellationToken);

    return new CreateChannelResult(true, command.WorkspaceId, channel.Id);
  }
}
