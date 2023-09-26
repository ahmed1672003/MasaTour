namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
public record class UpdateTripCommand(UpdateTripDto dto) : IRequest<ResponseModel<GetTripDto>>;
