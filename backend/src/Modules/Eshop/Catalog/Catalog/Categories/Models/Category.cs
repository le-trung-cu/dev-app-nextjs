using Shared.DDD;

namespace Catalog.Categories.Models;

public class Category : Aggregate<Guid>
{
  public string Name { get; set; }
  public string Slug { get; set; }
  public string? Color { get; set; }
  public List<Category> Subcategories { get; set; } = [];

  public Guid? ParentCategoryId { get; set; }
  public Category? ParentCategory { get; set; }
}
