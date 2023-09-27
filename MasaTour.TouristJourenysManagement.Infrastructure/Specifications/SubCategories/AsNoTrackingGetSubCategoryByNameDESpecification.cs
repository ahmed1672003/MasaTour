namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingGetSubCategoryByNameDESpecification : Specification<SubCategory>
{
    public AsNoTrackingGetSubCategoryByNameDESpecification(string nameDE) : base(sc => sc.NameDE.Equals(nameDE))
    {
        StopTracking();
    }
}
