namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameARSpecification : Specification<SubCategory>
{
    public AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameARSpecification(string subCategoryId, string nameAR)
        : base(sc => sc.NameAR.Equals(nameAR) && !sc.Id.Equals(subCategoryId) && sc.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
