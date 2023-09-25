using MasaTour.TouristJourenysManagement.Domain.Entities;

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Context;
public interface ITouristJourenysManagementDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<RoleClaim> RoleClaims { get; }
    DbSet<UserClaim> UserClaims { get; }
    DbSet<UserLogin> UserLogins { get; }
    DbSet<UserRoleMapper> UserRoles { get; }
    DbSet<UserToken> UserTokens { get; }
    DbSet<UserJWT> UserJWTs { get; }
    DbSet<Category> Categories { get; }
    DbSet<Journey> Journeys { get; }
    DbSet<CategoriesJourneysMapper> CategoryJourneys { get; }
    ValueTask DisposeAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DatabaseFacade Database { get; }
}
