namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;

public sealed class AsNoTrackingPaginateDeletedCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingPaginateDeletedCategoriesSpecification(int pageNumber = 1, int pageSize = 10, string keyWords = "", Expression<Func<Category, object>> orderBy = null)
        : base(category =>
        (category.IsDeleted) &
        (category.Id.ToLower().Contains(keyWords.ToLower()) ||
        category.NameAR.ToLower().Contains(keyWords.ToLower()) ||
        category.NameEN.ToLower().Contains(keyWords.ToLower()) ||
        category.NameDE.ToLower().Contains(keyWords.ToLower())))
    {
        IgnorQueryFilter();
        ApplyPaging((pageNumber, pageSize));
        AddOrderBy(orderBy);
    }
}
