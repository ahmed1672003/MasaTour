namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories;
public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
