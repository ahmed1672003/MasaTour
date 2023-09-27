namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingCheckDuplicatedDeletedCategoryByNameENSpecification : Specification<Category>
{
    public AsNoTrackingCheckDuplicatedDeletedCategoryByNameENSpecification(string categoryId, string nameEN)
        : base(c => c.NameEN.Equals(nameEN) && !c.Id.Equals(categoryId) && c.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
