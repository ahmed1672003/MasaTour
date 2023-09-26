namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Commands;
public record ConfirmeEmailCommand(ConfirmeEmailDto dto) : IRequest<ResponseModel<AuthModel>>;