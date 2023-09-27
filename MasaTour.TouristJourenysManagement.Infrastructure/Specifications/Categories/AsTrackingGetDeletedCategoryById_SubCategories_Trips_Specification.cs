namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;

public sealed class AsTrackingGetDeletedCategoryById_SubCategories_Trips_Specification : Specification<Category>
{
    public AsTrackingGetDeletedCategoryById_SubCategories_Trips_Specification(string categoryId) : base(category => category.Id.Equals(categoryId) && category.IsDeleted)
    {
        IgnorQueryFilter();
        AddIncludesString($"{nameof(Category.SubCategories)}.{nameof(SubCategory.Trips)}");
    }
}
