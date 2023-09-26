namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetAllDeletedCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingGetAllDeletedCategoriesSpecification() : base(category => category.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
