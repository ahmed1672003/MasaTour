namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class TripMandatoryMapperRepository : Repository<TripMandatoryMapper>, ITripMandatoryMapperRepository
{
    public TripMandatoryMapperRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
