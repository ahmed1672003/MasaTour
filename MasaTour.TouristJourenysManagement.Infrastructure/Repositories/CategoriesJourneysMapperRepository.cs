namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories;
public sealed class CategoriesJourneysMapperRepository : Repository<CategoriesJourneysMapper>, ICategoriesJourneysMapperRepository
{
    public CategoriesJourneysMapperRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
