using System.Reflection;
using Auth.Data.Configurations;

namespace Auth.Data;

public class AuthDbContext
  (DbContextOptions<AuthDbContext> options)
  : IdentityDbContext<User, IdentityRole, string,
                      IdentityUserClaim<string>, IdentityUserRole<string>,
                      IdentityUserLogin<string>, IdentityRoleClaim<string>,
                      AppUserToken>(options)
{
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.HasDefaultSchema("auth");
    base.OnModelCreating(builder);

    builder.ApplyConfiguration(new UserConfiguration());
    builder.ApplyConfiguration(new RoleConfiguration());
    builder.ApplyConfiguration(new UserRoleConfiguration());
  }
}
