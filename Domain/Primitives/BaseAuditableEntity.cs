namespace Domain.Primitives;

public abstract class BaseAuditableEntity : BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public bool Available { get; set; }
}