namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Queries;
public sealed record GetAllUsersQuery() : IRequest<ResponseModel<IEnumerable<GetUserDto>>>;
