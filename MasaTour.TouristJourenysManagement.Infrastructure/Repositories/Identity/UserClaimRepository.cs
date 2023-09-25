namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public sealed class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
{
    public UserClaimRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
