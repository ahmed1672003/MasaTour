namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Commands;
public sealed record ChangePasswordCommand(ChangePassowrdDto dto) : IRequest<ResponseModel<AuthModel>>;
