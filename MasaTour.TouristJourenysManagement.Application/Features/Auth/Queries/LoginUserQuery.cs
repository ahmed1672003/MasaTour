namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Queries;
public sealed record LoginUserQuery(LoginUserDto dto) : IRequest<ResponseModel<AuthModel>>;

