using System.ComponentModel.DataAnnotations;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Queries;
public sealed record GetUserByIdQuery([Required] string Id) : IRequest<ResponseModel<GetUserDto>>;
