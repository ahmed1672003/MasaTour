namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingCheckDuplicatedCategoryByNameDESpecification : Specification<Category>
{
    public AsNoTrackingCheckDuplicatedCategoryByNameDESpecification(string categoryId, string nameDE)
        : base(category => category.NameDE.Equals(nameDE) && !category.Id.Equals(nameDE))
    {
        StopTracking();
    }
}
