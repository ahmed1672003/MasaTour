namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public sealed class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
{
    public UserLoginRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
