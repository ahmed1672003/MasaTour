namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameDESpecification : Specification<SubCategory>
{
    public AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameDESpecification(string subCategoryId, string nameAR)
        : base(sc => sc.NameAR.Equals(nameAR) && !sc.Id.Equals(subCategoryId) && sc.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
