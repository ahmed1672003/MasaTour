namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
