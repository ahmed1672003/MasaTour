namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetAllNotActiveCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingGetAllNotActiveCategoriesSpecification() : base(category => !category.IsActive)
    {
        StopTracking();
    }
}
