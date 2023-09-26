namespace MasaTour.TouristTripsManagement.Application.Features.Users.Commands;
public sealed record UndoDeleteUserByIdCommand(string Id) : IRequest<ResponseModel<GetUserDto>>;
