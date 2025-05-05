namespace Catalog.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder
      .HasMany(x => x.Subcategories)
      .WithOne(x => x.ParentCategory)
      .HasForeignKey(x => x.ParentCategoryId);
  }
}
