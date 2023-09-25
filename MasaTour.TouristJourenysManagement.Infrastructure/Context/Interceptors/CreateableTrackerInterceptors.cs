using MasaTour.TouristJourenysManagement.Domain.Abstracts;

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Context.Interceptors;
public sealed class CreateableTrackerInterceptors : SaveChangesInterceptor
{
    public sealed override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { State: EntityState.Added, Entity: ICreateableTracker entity })
                continue;

            await entity.CreateAsync();
        }
        return result;
    }
}
