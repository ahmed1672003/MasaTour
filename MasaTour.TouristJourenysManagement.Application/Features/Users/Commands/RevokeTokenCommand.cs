namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record RevokeTokenCommand(RevokeTokenRequestDto dto) : IRequest<ResponseModel<AuthModel>>;