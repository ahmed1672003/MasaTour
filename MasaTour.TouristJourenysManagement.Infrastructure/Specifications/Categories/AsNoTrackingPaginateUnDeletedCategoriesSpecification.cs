namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingPaginateUnDeletedCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingPaginateUnDeletedCategoriesSpecification(int pageNumber = 1, int pageSize = 10, string keyWords = "", Expression<Func<Category, object>> orderBy = null)
        : base(category =>
        category.Id.ToLower().Contains(keyWords.ToLower()) ||
        category.NameAR.ToLower().Contains(keyWords.ToLower()) ||
        category.NameEN.ToLower().Contains(keyWords.ToLower()) ||
        category.NameDE.ToLower().Contains(keyWords.ToLower()))
    {
        ApplyPaging((pageNumber, pageSize));
        AddOrderBy(orderBy = category => category.CreatedAt);
    }
}
