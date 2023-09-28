namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingPaginateUnDeletedSubCategoriesSpecification : Specification<SubCategory>
{
    public AsNoTrackingPaginateUnDeletedSubCategoriesSpecification(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<SubCategory, object>> orderBy = null)
        : base(sc => sc.Id.Contains(keyWords) || sc.NameEN.Contains(keyWords) || sc.NameAR.Contains(keyWords) || sc.NameDE.Contains(keyWords))
    {
        StopTracking();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy);
    }
}
