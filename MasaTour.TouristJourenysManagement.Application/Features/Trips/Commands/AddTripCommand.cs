namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
public sealed record AddTripCommand(AddTripDto dto) : IRequest<ResponseModel<GetTripDto>>;
