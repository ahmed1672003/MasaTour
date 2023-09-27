namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingCheckDuplicatedSubCategoryByNameARSpecification : Specification<SubCategory>
{
    public AsNoTrackingCheckDuplicatedSubCategoryByNameARSpecification(string subCategoryId, string nameAR)
        : base(sc => sc.NameAR.Equals(nameAR) && !sc.Id.Equals(subCategoryId))
    {
        StopTracking();
    }
}
