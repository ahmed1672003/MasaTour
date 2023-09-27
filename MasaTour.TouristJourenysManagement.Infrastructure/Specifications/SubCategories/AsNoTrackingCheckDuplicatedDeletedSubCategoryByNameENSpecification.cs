namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameENSpecification : Specification<SubCategory>
{
    public AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameENSpecification(string subCategoryId, string nameEN)
        : base(sc => sc.NameEN.Equals(nameEN) && sc.Id.Equals(subCategoryId) && sc.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
