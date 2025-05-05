using System;
using Catalog.Categories.Models;
using Catalog.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
  public DbSet<Category> Categories => Set<Category>();
  public DbSet<Product> Products => Set<Product>();


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("eshop.catalog");
    base.OnModelCreating(modelBuilder);
  }
}
