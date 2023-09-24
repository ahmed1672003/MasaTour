using System.ComponentModel.DataAnnotations;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
public sealed record MakeUserVisibleByIdCommand([Required] string UserId) : IRequest<ResponseModel<GetUserDto>>;
