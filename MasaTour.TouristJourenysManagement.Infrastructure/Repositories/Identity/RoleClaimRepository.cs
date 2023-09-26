namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class RoleClaimRepository : Repository<RoleClaim>, IRoleClaimRepository
{
    public RoleClaimRepository(ITouristTripsManagementDbContext context) : base(context) { }
}
