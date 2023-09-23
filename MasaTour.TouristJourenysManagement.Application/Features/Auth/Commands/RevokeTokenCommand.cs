namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Commands;
public sealed record RevokeTokenCommand(RevokeTokenRequestDto dto) : IRequest<ResponseModel<AuthModel>>;