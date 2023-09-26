namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetAllCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingGetAllCategoriesSpecification()
    {
        IgnorQueryFilter();
    }
}
