using MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
using MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;
using MasaTour.TouristJourenysManagement.Application.Response;
using MasaTour.TouristJourenysManagement.Infrastructure.Enums;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace MasaTour.TouristJourenysManagement.API.Controllers;
[Authorize(AuthenticationSchemes = "Bearer", Roles = nameof(Roles.Basic))]
[ApiController]
public class UserController : MasaTourController
{
    public UserController(IMediator mediator) : base(mediator) { }

    #region Put
    [HttpPut(Router.User.UpdateUser)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetUserDto>))]
    [SwaggerOperation(OperationId = EndPoints.User.UpdateUser.OperationId, Summary = EndPoints.User.UpdateUser.Summary, Description = EndPoints.User.UpdateUser.Description)]
    public async Task<IActionResult> UpdateUser(UpdateUserDto dto) => MasaTourResponse(await Mediator.Send(new UpdateUserCommand(dto)));
    #endregion
}
