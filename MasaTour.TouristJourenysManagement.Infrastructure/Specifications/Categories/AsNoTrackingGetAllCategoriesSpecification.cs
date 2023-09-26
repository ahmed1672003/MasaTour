namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetAllCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingGetAllCategoriesSpecification()
    {
        IgnorQueryFilter();
    }
}
