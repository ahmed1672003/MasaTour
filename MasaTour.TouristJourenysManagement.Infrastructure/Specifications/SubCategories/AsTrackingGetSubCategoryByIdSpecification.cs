namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsTrackingGetSubCategoryByIdSpecification : Specification<SubCategory>
{
    public AsTrackingGetSubCategoryByIdSpecification(string id) : base(sc => sc.Id.Equals(id))
    {

    }
}
