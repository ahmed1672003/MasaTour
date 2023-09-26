namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetAllActiveCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingGetAllActiveCategoriesSpecification() : base(category => category.IsActive)
    {
        StopTracking();
    }
}
