namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class TripPhaseRepository : Repository<TripPhase>, ITripPhaseRepository
{
    public TripPhaseRepository(ITouristTripsManagementDbContext context) : base(context) { }
}
