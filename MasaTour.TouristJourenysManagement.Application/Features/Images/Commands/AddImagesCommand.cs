
namespace MasaTour.TouristTripsManagement.Application.Features.Images.Commands;
public sealed record AddImagesCommand(IEnumerable<IFormFile> Files) : IRequest<ResponseModel<IEnumerable<GetImageDto>>>;
