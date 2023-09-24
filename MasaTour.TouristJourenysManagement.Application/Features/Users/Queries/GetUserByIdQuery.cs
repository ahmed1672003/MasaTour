namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Queries;
public sealed record GetUserByIdQuery(string Id) : IRequest<ResponseModel<GetUserDto>>;
