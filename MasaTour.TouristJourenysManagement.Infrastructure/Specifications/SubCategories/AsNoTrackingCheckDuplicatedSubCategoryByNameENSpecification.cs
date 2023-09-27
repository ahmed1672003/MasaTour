namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingCheckDuplicatedSubCategoryByNameENSpecification : Specification<SubCategory>
{
    public AsNoTrackingCheckDuplicatedSubCategoryByNameENSpecification(string subCategoryId, string nameEN)
        : base(sc => sc.NameEN.Equals(nameEN) && !sc.Id.Equals(subCategoryId))
    {

        StopTracking();
    }
}
