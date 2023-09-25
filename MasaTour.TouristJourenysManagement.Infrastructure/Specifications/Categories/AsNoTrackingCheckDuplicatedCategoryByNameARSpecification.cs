namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingCheckDuplicatedCategoryByNameARSpecification : Specification<Category>
{
    public AsNoTrackingCheckDuplicatedCategoryByNameARSpecification(string categoryId, string nameAR)
        : base(category => category.NameAR.Equals(nameAR) && !category.Id.Equals(categoryId))
    {
        StopTracking();
    }
}
