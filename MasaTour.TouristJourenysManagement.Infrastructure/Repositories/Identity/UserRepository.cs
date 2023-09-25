namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ITouristJourenysManagementDbContext context) : base(context) { }
}
