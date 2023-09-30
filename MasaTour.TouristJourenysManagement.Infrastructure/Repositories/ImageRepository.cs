namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class ImageRepository : Repository<Image>, IImageRepository
{


    public ImageRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }

}
