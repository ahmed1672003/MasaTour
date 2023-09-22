namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record DeleteAllUsersCommand() : IRequest<ResponseModel<GetUserDto>>;

