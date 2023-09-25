using MasaTour.TouristJourenysManagement.Services.Dtos.Auth;

namespace MasaTour.TouristJourenysManagement.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer", Roles = nameof(Roles.Basic))]
[ApiController]
public class AuthController : MasaTourController
{
    public AuthController(IMediator mediator) : base(mediator) { }
    #region Post
    [HttpPost(Router.Auth.AddUser)]
    [AllowAnonymous]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<AuthModel>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.AddUser.OperationId, Summary = EndPoints.Auth.AddUser.Summary, Description = EndPoints.Auth.AddUser.Description)]
    public async Task<IActionResult> AddUser([FromBody] AddUserDto dto) => MasaTourResponse(await Mediator.Send(new AddUserCommand(dto)));
    #endregion

    #region Put
    [HttpPut(Router.Auth.LoginUser)]
    [AllowAnonymous]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<AuthModel>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.LoginUser.OperationId, Summary = EndPoints.Auth.LoginUser.Summary, Description = EndPoints.Auth.LoginUser.Description)]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDto dto) => MasaTourResponse(await Mediator.Send(new LoginUserQuery(dto)));

    [HttpPut(Router.Auth.RefreshToken)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<AuthModel>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.RefreshUserToken.OperationId, Summary = EndPoints.Auth.RefreshUserToken.Summary, Description = EndPoints.Auth.RefreshUserToken.Description)]
    public async Task<IActionResult> RefreshUserToken([FromBody] RefreshTokenRequestDto dto) => MasaTourResponse(await Mediator.Send(new RefreshTokenCommand(dto)));
    #endregion

    #region Patch
    [HttpPatch(Router.Auth.RevokeToken)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<AuthModel>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.RevokeUserToken.OperationId, Summary = EndPoints.Auth.RevokeUserToken.Summary, Description = EndPoints.Auth.RevokeUserToken.Description)]
    public async Task<IActionResult> RevokeUserToken([FromBody] RevokeTokenRequestDto dto) => MasaTourResponse(await Mediator.Send(new RevokeTokenCommand(dto)));

    [HttpPatch(Router.Auth.ChangePassword)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<dynamic>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.ChangePassword.OperationId, Summary = EndPoints.Auth.ChangePassword.Summary, Description = EndPoints.Auth.ChangePassword.Description)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePassowrdDto dto) => MasaTourResponse(await Mediator.Send(new ChangePasswordCommand(dto)));
    #endregion

    #region Get
    [AllowAnonymous]
    [HttpGet(Router.Auth.ConfirmeEmail)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<dynamic>))]
    [SwaggerOperation(OperationId = EndPoints.Auth.ConfirmEmail.OperationId, Summary = EndPoints.Auth.ConfirmEmail.Summary, Description = EndPoints.Auth.ConfirmEmail.Description)]
    public async Task<IActionResult> ConfirmeEmail([FromQuery] ConfirmeEmailDto dto) => MasaTourResponse(await Mediator.Send(new ConfirmeEmailCommand(dto)));
    #endregion
}
