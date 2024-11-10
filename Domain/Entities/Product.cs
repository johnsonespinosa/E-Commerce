using Domain.Primitives;

namespace Domain.Entities;

public class Product : BaseAuditableEntity
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal SellPrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Stock { get; set; }

    public Category? Category { get; private set; }
}