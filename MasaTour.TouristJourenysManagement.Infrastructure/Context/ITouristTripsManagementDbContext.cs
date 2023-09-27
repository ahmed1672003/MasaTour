using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MasaTour.TouristTripsManagement.Infrastructure.Context;
public interface ITouristTripsManagementDbContext
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
    DbSet<SubCategory> SubCategories { get; }
    DbSet<Trip> Trips { get; }
    ValueTask DisposeAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DatabaseFacade Database { get; }
}
