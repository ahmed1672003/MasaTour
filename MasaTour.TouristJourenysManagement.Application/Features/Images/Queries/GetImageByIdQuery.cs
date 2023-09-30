namespace MasaTour.TouristTripsManagement.Application.Features.Images.Queries;
public sealed record GetImageByIdQuery([Required] string ImageId) : IRequest<ResponseModel<GetImageDto>>;

