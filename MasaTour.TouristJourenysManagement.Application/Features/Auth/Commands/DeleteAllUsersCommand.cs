namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Commands;
public sealed record DeleteAllUsersCommand() : IRequest<ResponseModel<GetUserDto>>;

