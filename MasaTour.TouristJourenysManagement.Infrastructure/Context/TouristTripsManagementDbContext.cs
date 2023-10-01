using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MasaTour.TouristTripsManagement.Infrastructure.Context;
public class TouristTripsManagementDbContext
    : IdentityDbContext<User, Role, string, UserClaim, UserRoleMapper, UserLogin, RoleClaim, UserToken>,
    ITouristTripsManagementDbContext
{
    public TouristTripsManagementDbContext(DbContextOptions<TouristTripsManagementDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RoleClaim> RoleClaims => Set<RoleClaim>();
    public DbSet<UserClaim> UserClaims => Set<UserClaim>();
    public DbSet<UserLogin> UserLogins => Set<UserLogin>();
    public DbSet<UserRoleMapper> UserRoles => Set<UserRoleMapper>();
    public DbSet<UserToken> UserTokens => Set<UserToken>();
    public DbSet<UserJWT> UserJWTs => Set<UserJWT>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<SubCategory> SubCategories => Set<SubCategory>();
    public DbSet<Trip> Trips => Set<Trip>();
    public DbSet<TripPhase> TripPhases => Set<TripPhase>();
    public DbSet<TripMandatoryMapper> TripMandatoryMappers => Set<TripMandatoryMapper>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<Mandatory> Mandatories => Set<Mandatory>();
    public DbSet<TripImageMapper> TripImageMapper => Set<TripImageMapper>();
}
