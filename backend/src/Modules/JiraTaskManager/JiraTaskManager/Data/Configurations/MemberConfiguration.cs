using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraTaskManager.Data.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
  public void Configure(EntityTypeBuilder<Member> builder)
  {
    builder.Property(x => x.Role).HasConversion<string>();
  }
}
