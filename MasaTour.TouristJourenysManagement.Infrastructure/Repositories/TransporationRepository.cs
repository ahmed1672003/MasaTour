namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class TransporationRepository : Repository<Transportation>, ITransporationRepository
{
    public TransporationRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
