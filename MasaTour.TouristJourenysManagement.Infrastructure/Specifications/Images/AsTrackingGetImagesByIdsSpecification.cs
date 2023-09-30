namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Images;
public sealed class AsTrackingGetImagesByIdsSpecification : Specification<Image>
{
    public AsTrackingGetImagesByIdsSpecification(List<string> imagesIds) : base(img => imagesIds.Contains(img.Id))
    {
    }
}
