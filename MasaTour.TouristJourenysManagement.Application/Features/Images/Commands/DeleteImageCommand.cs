namespace MasaTour.TouristTripsManagement.Application.Features.Images.Commands;
public sealed record DeleteImageCommand(string Id, string Path) : IRequest<ResponseModel<GetImageDto>>;

