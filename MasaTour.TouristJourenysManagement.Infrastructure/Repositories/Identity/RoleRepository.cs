namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public sealed class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
