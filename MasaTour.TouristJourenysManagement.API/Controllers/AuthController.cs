using MasaTour.TouristJourenysManagement.Application.Response;
using MasaTour.TouristJourenysManagement.Infrastructure.Enums;
using MasaTour.TouristJourenysManagement.Services.Dtos.Auth;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace MasaTour.TouristJourenysManagement.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer", Roles = nameof(Roles.Basic))]
[ApiController]
public class AuthController : MasaTourController
{
    public AuthController(IMediator mediator) : base(mediator) { }

    #region Post
    [AllowAnonymous]
    [HttpPost(Router.Auth.AddUser)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<AuthModel>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.AddUser.OperationId, Summary = EndPoints.Auth.AddUser.Summary, Description = EndPoints.Auth.AddUser.Description)]
    public async Task<IActionResult> AddUser([FromForm] AddUserDto dto) => MasaTourResponse(await Mediator.Send(new AddUserCommand(dto)));
    #endregion

    #region Put
    [AllowAnonymous]
    [HttpPut(Router.Auth.LoginUser)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<AuthModel>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.LoginUser.OperationId, Summary = EndPoints.Auth.LoginUser.Summary, Description = EndPoints.Auth.LoginUser.Description)]
    public async Task<IActionResult> LoginUser([FromForm] LoginUserDto dto) => MasaTourResponse(await Mediator.Send(new LoginUserQuery(dto)));

    [HttpPut(Router.Auth.RefreshToken)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<AuthModel>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.RefreshUserToken.OperationId, Summary = EndPoints.Auth.RefreshUserToken.Summary, Description = EndPoints.Auth.RefreshUserToken.Description)]
    public async Task<IActionResult> RefreshUserToken([FromForm] RefreshTokenRequestDto dto) => MasaTourResponse(await Mediator.Send(new RefreshTokenCommand(dto)));
    #endregion

    #region Patch
    [HttpPatch(Router.Auth.RevokeToken)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<AuthModel>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.RevokeUserToken.OperationId, Summary = EndPoints.Auth.RevokeUserToken.Summary, Description = EndPoints.Auth.RevokeUserToken.Description)]
    public async Task<IActionResult> RevokeUserToken([FromForm] RevokeTokenRequestDto dto) => MasaTourResponse(await Mediator.Send(new RevokeTokenCommand(dto)));
    #endregion

    #region Get
    [Authorize(Roles = nameof(Roles.SuperAdmin))]
    [HttpGet(Router.Auth.GetAllUsers)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetUserDto>>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.GetAllUsers.OperationId, Summary = EndPoints.Auth.GetAllUsers.Summary, Description = EndPoints.Auth.GetAllUsers.Description)]
    public async Task<IActionResult> GetAllUsers() => MasaTourResponse(await Mediator.Send(new GetAllUsersQuery()));
    #endregion

    #region Delete
    [Authorize(Roles = nameof(Roles.SuperAdmin))]
    [HttpDelete(Router.Auth.DeleteAllUsers)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetUserDto>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.DeleteAllUsers.OperationId, Summary = EndPoints.Auth.DeleteAllUsers.Summary, Description = EndPoints.Auth.DeleteAllUsers.Description)]
    public async Task<IActionResult> DeleteAllUsers() => MasaTourResponse(await Mediator.Send(new DeleteAllUsersCommand()));
    #endregion
}
