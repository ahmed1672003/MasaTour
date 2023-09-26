namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class CategoriesTripsMapperRepository : Repository<CategoriesTripsMapper>, ICategoriesTripsMapperRepository
{
    public CategoriesTripsMapperRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
