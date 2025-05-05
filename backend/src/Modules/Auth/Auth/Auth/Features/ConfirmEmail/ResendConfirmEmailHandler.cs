using Shared.Exceptions;

namespace Auth.Auth.Features.ConfirmEmail;


public record ResendConfirmEmailCommand() : ICommand<ResendConfirmEmailResult>;

public record ResendConfirmEmailResult(bool IsSuccess);
public class ResendConfirmEmailHandler
  (UserManager<User> userManager, IHttpContextAccessor contextAccessor, ISender sender)
  : ICommandHandler<ResendConfirmEmailCommand, ResendConfirmEmailResult>
{
  public async Task<ResendConfirmEmailResult> Handle(ResendConfirmEmailCommand command, CancellationToken cancellationToken)
  {
    var claims = contextAccessor.HttpContext!.User;
    var user = await userManager.GetUserAsync(claims)
      ?? throw new BadRequestException("Invalid email");

    await sender.Send(new SendConfirmEmailCommand(user, user.Email), cancellationToken);

    return new ResendConfirmEmailResult(true);
  }
}
