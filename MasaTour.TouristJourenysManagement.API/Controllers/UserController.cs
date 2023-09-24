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

    #region Patch
    [HttpPatch(Router.User.DeleteUserById)]
    [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.SuperAdmin)}")]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<dynamic>))]
    [SwaggerOperation(OperationId = EndPoints.User.DeleteUserById.OperationId, Summary = EndPoints.User.DeleteUserById.Summary, Description = EndPoints.User.DeleteUserById.Description)]
    public async Task<IActionResult> DeleteUserById([Required] string userId) => MasaTourResponse(await Mediator.Send(new UndoDeleteUserByIdCommand(userId)));


    [HttpPatch(Router.User.UndoDeleteUserById)]
    [Authorize(Roles = $"{nameof(Roles.SuperAdmin)},{nameof(Roles.Admin)}")]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<dynamic>))]
    [SwaggerOperation(OperationId = EndPoints.User.UndoDeleteUserById.OperationId, Summary = EndPoints.User.UndoDeleteUserById.Summary, Description = EndPoints.User.UndoDeleteUserById.Description)]
    public async Task<IActionResult> UndoDeleteUserById([Required] string userId) => MasaTourResponse(await Mediator.Send(new DeleteUserByIdCommand(userId)));
    #endregion

    #region Get
    [HttpGet(Router.User.GetUserById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetUserDto>))]
    [SwaggerOperation(OperationId = EndPoints.User.GetUserById.OperationId, Summary = EndPoints.User.GetUserById.Summary, Description = EndPoints.User.GetUserById.Description)]
    public async Task<IActionResult> GetUserById([Required] string userId) => MasaTourResponse(await Mediator.Send(new GetUserByIdQuery(userId)));

    [Authorize(Roles = nameof(Roles.SuperAdmin))]
    [HttpGet(Router.User.GetAllUsers)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetUserDto>>))]
    [SwaggerOperation(OperationId = EndPoints.User.GetAllUsers.OperationId, Summary = EndPoints.User.GetAllUsers.Summary, Description = EndPoints.User.GetAllUsers.Description)]
    public async Task<IActionResult> GetAllUsers() => MasaTourResponse(await Mediator.Send(new GetAllUsersQuery()));


    #endregion

    #region Delete

    [Authorize(Roles = nameof(Roles.SuperAdmin))]
    [HttpDelete(Router.User.DeleteAllUsers)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<dynamic>))]
    [SwaggerOperation(OperationId = EndPoints.User.DeleteAllUsers.OperationId, Summary = EndPoints.User.DeleteAllUsers.Summary, Description = EndPoints.User.DeleteAllUsers.Description)]
    public async Task<IActionResult> DeleteAllUsers() => MasaTourResponse(await Mediator.Send(new DeleteAllUsersCommand()));
    #endregion
}
