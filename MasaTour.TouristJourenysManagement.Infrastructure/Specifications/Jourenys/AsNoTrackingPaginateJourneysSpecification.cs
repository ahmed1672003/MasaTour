namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingPaginateJourneysSpecification : Specification<Journey>
{
    public AsNoTrackingPaginateJourneysSpecification(int pageNumber = 1, int pageSize = 10, string keyWords = "", Expression<Func<Category, object>> orderBy = null)
        : base(j =>
            j.NameAR.Contains(keyWords) ||
            j.NameEN.Contains(keyWords) ||
            j.NameDE.Contains(keyWords) ||
            j.Code.Contains(keyWords) ||
            j.PriceEGP.ToString().Contains(keyWords) ||
            j.PriceUSD.ToString().Contains(keyWords) ||
            j.PriceEUR.ToString().Contains(keyWords) ||
            j.PriceGBP.ToString().Contains(keyWords) ||
            j.FromAR.ToString().Contains(keyWords) ||
            j.FromEN.ToString().Contains(keyWords) ||
            j.FromDE.ToString().Contains(keyWords) ||
            j.ToAR.ToString().Contains(keyWords) ||
            j.ToEN.ToString().Contains(keyWords) ||
            j.ToDE.ToString().Contains(keyWords) ||
            j.LongDesceiptionAR.ToString().Contains(keyWords) ||
            j.LongDesceiptionEN.ToString().Contains(keyWords) ||
            j.LongDesceiptionDE.ToString().Contains(keyWords) ||
            j.MiniDesceiptionAR.ToString().Contains(keyWords) ||
            j.MiniDesceiptionDE.ToString().Contains(keyWords) ||
            j.MiniDesceiptionEN.ToString().Contains(keyWords)
            )
    {
        StopTracking();
        ApplyPaging((pageNumber, pageSize));
        AddOrderBy(orderBy => orderBy.CreatedAt);
    }
}
