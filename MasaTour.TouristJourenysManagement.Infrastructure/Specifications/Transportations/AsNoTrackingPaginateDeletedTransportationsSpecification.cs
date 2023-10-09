namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;
public sealed class AsNoTrackingPaginateDeletedTransportationsSpecification : Specification<Transportation>
{
    public AsNoTrackingPaginateDeletedTransportationsSpecification
        (int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<Transportation, object>> orderBy = null)
        : base(t => (t.IsDeleted) &&
        (t.NumberOfSeats.ToString().Contains(keyWords) ||
         t.TransportationClassId.Contains(keyWords) ||
         t.Id.Contains(keyWords) ||
         t.Model.Contains(keyWords) ||
         t.DescriptionAR.Contains(keyWords) ||
         t.DescriptionDE.Contains(keyWords) ||
         t.DescriptionEN.Contains(keyWords)))
    {
        StopTracking();
        IgnorQueryFilter();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy = t => t.CreatedAt);
    }
}
