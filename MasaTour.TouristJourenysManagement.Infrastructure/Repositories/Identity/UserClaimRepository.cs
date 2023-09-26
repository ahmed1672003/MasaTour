namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
{
    public UserClaimRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
