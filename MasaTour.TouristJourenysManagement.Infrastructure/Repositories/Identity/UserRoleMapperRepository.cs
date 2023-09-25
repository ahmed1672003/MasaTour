namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public sealed class UserRoleMapperRepository : Repository<UserRoleMapper>, IUserRoleMapperRepository
{
    public UserRoleMapperRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
