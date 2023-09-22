namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record AddUserCommand(AddUserDto dto) : IRequest<ResponseModel<AuthModel>>;
