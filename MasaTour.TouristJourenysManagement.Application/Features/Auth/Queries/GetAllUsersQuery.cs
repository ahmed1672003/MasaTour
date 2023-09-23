namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Queries;
public sealed record GetAllUsersQuery() : IRequest<ResponseModel<IEnumerable<GetUserDto>>>;
