namespace MasaTour.TouristTripsManagement.Application.Features.Images.Commands;
public sealed record DeleteImageCommand(string Id) : IRequest<ResponseModel<GetImageDto>>;

