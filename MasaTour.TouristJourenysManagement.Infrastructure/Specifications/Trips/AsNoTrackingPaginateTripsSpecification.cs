namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingPaginateTripsSpecification : Specification<Trip>
{
    public AsNoTrackingPaginateTripsSpecification(int pageNumber = 1, int pageSize = 10, string keyWords = "", Expression<Func<Category, object>> orderBy = null)
        : base(t =>
            t.NameAR.Contains(keyWords) ||
            t.NameEN.Contains(keyWords) ||
            t.NameDE.Contains(keyWords) ||
            t.Code.Contains(keyWords) ||
            t.PriceEGP.ToString().Contains(keyWords) ||
            t.PriceUSD.ToString().Contains(keyWords) ||
            t.PriceEUR.ToString().Contains(keyWords) ||
            t.PriceGBP.ToString().Contains(keyWords) ||
            t.FromAR.ToString().Contains(keyWords) ||
            t.FromEN.ToString().Contains(keyWords) ||
            t.FromDE.ToString().Contains(keyWords) ||
            t.ToAR.ToString().Contains(keyWords) ||
            t.ToEN.ToString().Contains(keyWords) ||
            t.ToDE.ToString().Contains(keyWords) ||
            t.LongDesceiptionAR.ToString().Contains(keyWords) ||
            t.LongDesceiptionEN.ToString().Contains(keyWords) ||
            t.LongDesceiptionDE.ToString().Contains(keyWords) ||
            t.MiniDesceiptionAR.ToString().Contains(keyWords) ||
            t.MiniDesceiptionDE.ToString().Contains(keyWords) ||
            t.MiniDesceiptionEN.ToString().Contains(keyWords) ||
            t.CreatedAt.ToShortDateString().Contains(keyWords) ||
            t.CreatedAt.ToShortTimeString().Contains(keyWords))
    {
        StopTracking();
        ApplyPaging((pageNumber, pageSize));
        AddOrderBy(orderBy => orderBy.CreatedAt);
    }
}
