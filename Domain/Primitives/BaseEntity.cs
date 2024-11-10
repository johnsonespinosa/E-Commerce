using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Primitives;

/// <summary>
/// Representa una raíz de agregado en el dominio, que es un concepto clave en la arquitectura limpia.
/// Un agregado es un objeto que encapsula toda la lógica de negocio relacionada con un concepto específico,
/// manteniendo su estado interno y permitiendo operaciones como crear, leer, actualizar y eliminar (CRUD).
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Lista interna que almacena los eventos de dominio generados por las operaciones realizadas en esta raíz de agregado.
    /// Los eventos son objetos que representan cambios o acciones significativas dentro del sistema de dominio.
    /// </summary>
    private readonly List<DomainEvent> _domainEvents = [];

    /// <summary>
    /// Propiedad pública que expone la lista de eventos de dominio almacenados en la raíz de agregado.
    /// Permite acceder a los eventos generados sin modificarlos directamente.
    /// </summary>
    [NotMapped]
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Método protegido que permite generar un nuevo evento de dominio y agregarlo a la lista de eventos.
    /// Este método se utiliza para registrar eventos que ocurran durante las operaciones de negocio.
    /// </summary>
    /// <param name="domainEvent">El evento de dominio a agregar a la lista.</param>
    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}