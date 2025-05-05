using Microsoft.Extensions.Logging;

namespace Catalog.Data.Seed;

public class CatalogDataSeeder(ILogger<CatalogDataSeeder> logger, CatalogDbContext dbContext) : IDataSeeder
{
  public async Task SeedAllAsync()
  {
    var hasCategory = await dbContext.Categories.AnyAsync();
    logger.LogInformation("Seed Categories: {hasCategory}", !hasCategory);
    if(!hasCategory)
    {
      dbContext.Categories.AddRange(InitialData.Categories);
      await dbContext.SaveChangesAsync();
    }
  }
}
