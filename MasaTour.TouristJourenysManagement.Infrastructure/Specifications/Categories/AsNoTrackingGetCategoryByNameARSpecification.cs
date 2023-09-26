namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetCategoryByNameARSpecification : Specification<Category>
{
    public AsNoTrackingGetCategoryByNameARSpecification(string nameAR) : base(catgory => catgory.NameAR.Equals(nameAR))
    {
        StopTracking();
    }
}
