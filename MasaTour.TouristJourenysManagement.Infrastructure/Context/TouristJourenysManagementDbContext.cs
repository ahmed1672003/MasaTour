using System.Reflection;

using MasaTour.TouristJourenysManagement.Domain.Entities.Identity;

using Microsoft.EntityFrameworkCore;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Context;
public class TouristJourenysManagementDbContext : DbContext, ITouristJourenysManagementDbContext
{
    public TouristJourenysManagementDbContext(DbContextOptions<TouristJourenysManagementDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<User> Users { get; }
    public DbSet<Role> Roles { get; }
    public DbSet<RoleClaim> RoleClaims { get; }
    public DbSet<UserClaim> UserClaims { get; }
    public DbSet<UserLogin> UserLogins { get; }
    public DbSet<UserRole> UserRoles { get; }
    public DbSet<UserToken> UserTokens { get; }
    public DbSet<UserJWT> UserJWTs { get; }
}
