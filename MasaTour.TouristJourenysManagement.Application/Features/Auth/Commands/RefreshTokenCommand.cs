namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Commands;
public sealed record RefreshTokenCommand(RefreshTokenRequestDto dto) : IRequest<ResponseModel<AuthModel>>;
