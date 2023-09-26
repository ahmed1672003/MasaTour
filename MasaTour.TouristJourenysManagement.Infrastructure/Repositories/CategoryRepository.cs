namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
