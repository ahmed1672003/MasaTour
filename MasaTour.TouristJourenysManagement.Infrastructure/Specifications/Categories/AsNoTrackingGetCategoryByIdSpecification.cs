namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetCategoryByIdSpecification : Specification<Category>
{
    public AsNoTrackingGetCategoryByIdSpecification(string id) : base(category => category.Id.Equals(id))
    {
        StopTracking();
    }
}
