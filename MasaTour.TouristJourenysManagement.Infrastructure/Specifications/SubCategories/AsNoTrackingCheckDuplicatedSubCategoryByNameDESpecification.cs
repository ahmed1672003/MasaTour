namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingCheckDuplicatedSubCategoryByNameDESpecification : Specification<SubCategory>
{
    public AsNoTrackingCheckDuplicatedSubCategoryByNameDESpecification(string subCategoryId, string nameDE)
        : base(sc => sc.NameDE.Equals(nameDE) && !sc.Id.Equals(subCategoryId))
    {
        StopTracking();
    }
}
