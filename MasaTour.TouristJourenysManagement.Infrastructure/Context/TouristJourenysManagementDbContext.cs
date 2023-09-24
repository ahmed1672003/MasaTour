using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Context;
public class TouristJourenysManagementDbContext
    : IdentityDbContext<User, Role, string, UserClaim, UserRoleMapper, UserLogin, RoleClaim, UserToken>,
    ITouristJourenysManagementDbContext
{
    public TouristJourenysManagementDbContext(DbContextOptions<TouristJourenysManagementDbContext> options) : base(options) { }
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
}
