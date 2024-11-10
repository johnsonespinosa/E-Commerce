﻿using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors;

public class DispatchDomainEventsInterceptor(IPublisher mediator) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();

        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context == null) return;

        var entities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(entry => entry.Entity.DomainEvents.Count != 0)
            .Select(entry => entry.Entity)
            .ToList();

        var domainEvents = entities
            .SelectMany(entity => entity.DomainEvents)
            .ToList();

        entities.ToList().ForEach(entity => entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}