using MasaTour.TouristTripsManagement.Domain.Abstracts;

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Interceptors;
public sealed class UpdateableTrackerInterceptor : SaveChangesInterceptor
{
    public sealed override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            //if (entry is null || entry.State != EntityState.Modified || entry.Entity is not IUpdateableTracker)
            if (entry is not { State: EntityState.Modified, Entity: IUpdateableTracker entity })
                continue;
            await entity.UpdateAsync();
        }
        return result;
    }
}
