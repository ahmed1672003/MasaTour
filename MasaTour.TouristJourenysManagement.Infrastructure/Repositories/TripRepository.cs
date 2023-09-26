namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class TripRepository : Repository<Trip>, ITripRepository
{
    public TripRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
