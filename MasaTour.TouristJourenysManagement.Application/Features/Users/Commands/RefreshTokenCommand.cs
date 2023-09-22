namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record RefreshTokenCommand(RefreshTokenRequestDto dto) : IRequest<ResponseModel<AuthModel>>;
