namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class TransporationRepository : Repository<Transporation>, ITransporationRepository
{
    public TransporationRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
