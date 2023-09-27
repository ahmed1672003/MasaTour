namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingGetSubCategoryByNameENSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetSubCategoryByNameENSpecification(string nameEN) : base(sc => sc.NameEN.Equals(nameEN))
    {
        StopTracking();
    }
}
