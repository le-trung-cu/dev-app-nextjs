namespace Catalog.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.HasMany(x => x.Categories).WithMany(x => x.Products);
  }
}
