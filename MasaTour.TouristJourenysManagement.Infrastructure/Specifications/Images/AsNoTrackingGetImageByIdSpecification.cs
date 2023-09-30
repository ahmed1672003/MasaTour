namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Images;
public sealed class AsNoTrackingGetImageByIdSpecification : Specification<Image>
{
    public AsNoTrackingGetImageByIdSpecification(string id) : base(img => img.Id.Equals(id))
    {
        StopTracking();
    }
}
