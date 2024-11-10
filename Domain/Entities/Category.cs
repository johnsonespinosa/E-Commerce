using Domain.Primitives;

namespace Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string? Name { get; set; }
    public Guid? ParentId { get; set; } // Propiedad para la relación padre-hijo
    public Category? ParentCategory { get; set; } // Navegación hacia la categoría padre
    public IList<Category> SubCategories { get; private set; } = [];  // Colección de subcategorías
    public IList<Product> Products { get; private set; } = [];
}