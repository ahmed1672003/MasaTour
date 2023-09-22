namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Queries;
public sealed record LoginUserQuery(LoginUserDto dto) : IRequest<ResponseModel<AuthModel>>;

