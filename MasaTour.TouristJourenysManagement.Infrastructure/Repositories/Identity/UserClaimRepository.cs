using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
{
    public UserClaimRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
