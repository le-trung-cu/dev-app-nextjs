using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SlackChat.Data.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
  public void Configure(EntityTypeBuilder<Message> builder)
  {
    builder.HasOne(x => x.ParentMessage)
      .WithMany(x => x.Children)
      .HasForeignKey(x => x.ParentMessageId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
