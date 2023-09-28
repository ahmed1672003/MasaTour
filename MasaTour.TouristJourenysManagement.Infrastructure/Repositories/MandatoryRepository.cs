namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class MandatoryRepository : Repository<Mandatory>, IMandatoryRepository
{
    public MandatoryRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
