namespace MasaTour.TouristTripsManagement.Application.Features.Images.Commands;
public sealed record AddImageCommand(IFormFile File) : IRequest<ResponseModel<GetImageDto>>;
