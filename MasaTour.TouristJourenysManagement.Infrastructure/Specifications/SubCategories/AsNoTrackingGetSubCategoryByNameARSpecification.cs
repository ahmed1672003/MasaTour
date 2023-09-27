namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingGetSubCategoryByNameARSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetSubCategoryByNameARSpecification(string nameAR) : base(sc => sc.NameAR.Equals(nameAR))
    {
        StopTracking();
    }
}
