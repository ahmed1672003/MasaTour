namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
{
    public SubCategoryRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
