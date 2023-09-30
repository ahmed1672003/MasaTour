namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Images;
public sealed class AsNoTrackingPaginateImagesSpecification : Specification<Image>
{
    public AsNoTrackingPaginateImagesSpecification(int? pageNumber = 1, int? pageSize = 10, Expression<Func<Image, object>> orderBy = null)
    {
        StopTracking();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy);
    }
}
