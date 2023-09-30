namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class TripImageMapperRepository : Repository<TripImageMapper>, ITripImageMapperRepository
{
    public TripImageMapperRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
