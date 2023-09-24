namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record MakeUserHiddenByIdCommand(string Id) : IRequest<ResponseModel<GetUserDto>>;
