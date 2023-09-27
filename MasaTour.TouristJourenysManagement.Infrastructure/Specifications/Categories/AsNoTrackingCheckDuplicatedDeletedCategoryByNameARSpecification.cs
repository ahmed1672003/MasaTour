namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingCheckDuplicatedDeletedCategoryByNameARSpecification : Specification<Category>
{
    public AsNoTrackingCheckDuplicatedDeletedCategoryByNameARSpecification(string categoryId, string nameAR)
        : base(c => c.NameAR.Equals(nameAR) && c.Id.Equals(categoryId) && c.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
