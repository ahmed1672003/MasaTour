namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingPaginateUnDeletedTripsSpecification : Specification<Trip>
{
    public AsNoTrackingPaginateUnDeletedTripsSpecification(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<Trip, object>> orderBy = null)
        : base(t =>
            t.NameAR.Contains(keyWords) ||
            t.NameEN.Contains(keyWords) ||
            t.NameDE.Contains(keyWords) ||
            t.Code.Contains(keyWords) ||
            t.PriceEGP.ToString().Contains(keyWords) ||
            t.PriceUSD.ToString().Contains(keyWords) ||
            t.PriceEUR.ToString().Contains(keyWords) ||
            t.PriceGBP.ToString().Contains(keyWords) ||
            t.FromAR.Contains(keyWords) ||
            t.FromEN.Contains(keyWords) ||
            t.FromDE.Contains(keyWords) ||
            t.ToAR.Contains(keyWords) ||
            t.ToEN.Contains(keyWords) ||
            t.ToDE.Contains(keyWords) ||
            t.LongDescriptionAR.Contains(keyWords) ||
            t.LongDescriptionEN.Contains(keyWords) ||
            t.LongDesceiptionDE.Contains(keyWords) ||
            t.MiniDescriptionAR.Contains(keyWords) ||
            t.MiniDescriptionDE.Contains(keyWords) ||
            t.MiniDescriptionEN.Contains(keyWords))
    {
        StopTracking();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy => orderBy.CreatedAt);
    }
}
