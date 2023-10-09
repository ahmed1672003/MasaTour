namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class TransporationClassRepository : Repository<TransportationClass>, ITransporationClassRepository
{
    public TransporationClassRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
