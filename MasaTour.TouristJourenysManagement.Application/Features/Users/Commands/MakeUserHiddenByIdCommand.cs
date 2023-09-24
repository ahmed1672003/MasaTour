namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record UndoDeleteUserByIdCommand(string Id) : IRequest<ResponseModel<GetUserDto>>;
