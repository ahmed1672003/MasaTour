namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class UserRoleMapperRepository : Repository<UserRoleMapper>, IUserRoleMapperRepository
{
    public UserRoleMapperRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
