using MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;
using MasaTour.TouristJourenysManagement.Application.Response;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record AddUserCommand(AddUserDto dto) : IRequest<ResponseModel<GetUserDto>>;
