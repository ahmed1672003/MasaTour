namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public sealed class RoleClaimRepository : Repository<RoleClaim>, IRoleClaimRepository
{
    public RoleClaimRepository(ITouristJourenysManagementDbContext context) : base(context) { }
}
