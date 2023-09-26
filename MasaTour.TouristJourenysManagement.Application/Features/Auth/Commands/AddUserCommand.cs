namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Commands;
public sealed record AddUserCommand(AddUserDto dto) : IRequest<ResponseModel<AuthModel>>;
