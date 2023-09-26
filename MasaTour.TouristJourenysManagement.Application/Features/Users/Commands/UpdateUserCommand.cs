using MasaTour.TouristTripsManagement.Application.Features.Users.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.Users.Commands;
public sealed record UpdateUserCommand(UpdateUserDto dto) : IRequest<ResponseModel<GetUserDto>>;
