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
    DbSet<TripPhase> TripPhases { get; }
    DbSet<TripMandatoryMapper> TripMandatoryMappers { get; }
    DbSet<Mandatory> Mandatories { get; }
    DbSet<Image> Images { get; }
    DbSet<TripImageMapper> TripImageMapper { get; }
    DbSet<Comment> Comments { get; }
    DbSet<Transporation> Transporations { get; }
    DbSet<TransporationClass> TransporationClasses { get; }

    ValueTask DisposeAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DatabaseFacade Database { get; }
}
