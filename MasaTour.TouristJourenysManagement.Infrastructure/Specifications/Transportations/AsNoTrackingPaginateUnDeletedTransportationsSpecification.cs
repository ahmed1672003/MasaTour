namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;
public sealed class AsNoTrackingPaginateUnDeletedTransportationsSpecification : Specification<Transportation>
{
    public AsNoTrackingPaginateUnDeletedTransportationsSpecification(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<Transportation, object>> orderBy = null)
        : base(t =>
        t.NumberOfSeats.ToString().Contains(keyWords) ||
         t.TransportationClassId.Contains(keyWords) ||
         t.Id.Contains(keyWords) ||
         t.Model.Contains(keyWords) ||
         t.DescriptionAR.Contains(keyWords) ||
         t.DescriptionDE.Contains(keyWords) ||
         t.DescriptionEN.Contains(keyWords))
    {
        StopTracking();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy = t => t.CreatedAt);
    }
}
