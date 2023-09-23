using MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record UpdateUserCommand(UpdateUserDto dto) : IRequest<ResponseModel<GetUserDto>>;
