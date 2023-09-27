namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsTrackingGetDeletedSubCategoryById_Trips_Specification : Specification<SubCategory>
{
    public AsTrackingGetDeletedSubCategoryById_Trips_Specification(string subCategoryId)
        : base(sc => sc.Id.Equals(subCategoryId) && sc.IsDeleted)
    {
        IgnorQueryFilter();
        AddIncludesString($"{nameof(SubCategory.Trips)}");
    }
}
