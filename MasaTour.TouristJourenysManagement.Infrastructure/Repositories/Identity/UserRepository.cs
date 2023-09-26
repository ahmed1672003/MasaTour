namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ITouristTripsManagementDbContext context) : base(context) { }
}
