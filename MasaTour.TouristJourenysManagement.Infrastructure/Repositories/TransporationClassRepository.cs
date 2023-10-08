namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class TransporationClassRepository : Repository<TransporationClass>, ITransporationClassRepository
{
    public TransporationClassRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
