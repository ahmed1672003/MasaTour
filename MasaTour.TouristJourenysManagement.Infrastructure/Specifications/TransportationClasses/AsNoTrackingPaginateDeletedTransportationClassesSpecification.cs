namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingPaginateDeletedTransportationClassesSpecification : Specification<TransporationClass>
{
    public AsNoTrackingPaginateDeletedTransportationClassesSpecification(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<TransporationClass, object>> orderBy = null)
        : base(t => (t.IsDeleted) &&
        (t.PriceGbpPerKilometer.ToString().Contains(keyWords) ||
         t.PriceEURPerKilometer.ToString().Contains(keyWords) ||
         t.PriceEGPPerKilometer.ToString().Contains(keyWords) ||
         t.PriceUSDPerKilometer.ToString().Contains(keyWords) ||
         t.DescriptionAR.Contains(keyWords) ||
         t.DescriptionDE.Contains(keyWords) ||
         t.DescriptionEN.Contains(keyWords)))
    {
        StopTracking();
        IgnorQueryFilter();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy => orderBy.CreatedAt);
    }
}
