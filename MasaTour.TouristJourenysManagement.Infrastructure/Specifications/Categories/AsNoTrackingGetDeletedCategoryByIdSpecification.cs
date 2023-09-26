namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetDeletedCategoryByIdSpecification : Specification<Category>
{
    public AsNoTrackingGetDeletedCategoryByIdSpecification(string categoryId) : base(category => category.Id.Equals(categoryId) && category.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
