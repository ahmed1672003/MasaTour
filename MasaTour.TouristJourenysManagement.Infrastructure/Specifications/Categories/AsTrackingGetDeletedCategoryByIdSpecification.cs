namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsTrackingGetDeletedCategoryByIdSpecification : Specification<Category>
{
    public AsTrackingGetDeletedCategoryByIdSpecification(string categoryId) : base(category => category.Id.Equals(categoryId) && category.IsDeleted)
    {
        IgnorQueryFilter();
    }
}
