﻿using MasaTour.TouristJourenysManagement.Domain.Abstracts;

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Context.Interceptors;
public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public sealed override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            //if (entry is null || entry.State != EntityState.Deleted || entry.Entity is not ISoftDeleteable)
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDeleteable entity })
                continue;

            entry.State = EntityState.Modified;
            await entity.DeleteAsync();
        }
        return result;
    }
}
