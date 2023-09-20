using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class RoleClaimRepository : Repository<RoleClaim>, IRoleClaimRepository
{
    public RoleClaimRepository(ITouristJourenysManagementDbContext context) : base(context) { }
}
