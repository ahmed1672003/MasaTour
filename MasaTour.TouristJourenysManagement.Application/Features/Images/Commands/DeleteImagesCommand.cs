namespace MasaTour.TouristTripsManagement.Application.Features.Images.Commands;
public sealed record DeleteImagesCommand(List<string> ImagesIds) : IRequest<ResponseModel<IEnumerable<GetImageDto>>>;