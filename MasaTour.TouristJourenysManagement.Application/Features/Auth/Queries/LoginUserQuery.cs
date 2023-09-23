namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Queries;
public sealed record LoginUserQuery(LoginUserDto dto) : IRequest<ResponseModel<AuthModel>>;

