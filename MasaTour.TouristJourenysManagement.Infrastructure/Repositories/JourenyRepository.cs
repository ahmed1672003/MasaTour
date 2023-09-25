namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories;
public sealed class JourenyRepository : Repository<Journey>, IJourenyRepository
{
    public JourenyRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
