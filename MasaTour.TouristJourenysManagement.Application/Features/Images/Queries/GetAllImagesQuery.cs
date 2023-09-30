namespace MasaTour.TouristTripsManagement.Application.Features.Images.Queries;
public sealed record GetAllImagesQuery() : IRequest<ResponseModel<IEnumerable<GetImageDto>>>;
