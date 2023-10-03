namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
public sealed record DeleteImagesFromTripCommand(string TripId, List<string> ImagesIds) : IRequest<ResponseModel<GetTripDto>>;
