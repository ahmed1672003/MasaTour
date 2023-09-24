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
    [HttpPatch(Router.User.MakeUserHidden)]
    [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.SuperAdmin)}")]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<dynamic>))]
    [SwaggerOperation(OperationId = EndPoints.User.MakeUserHidden.OperationId, Summary = EndPoints.User.MakeUserHidden.Summary, Description = EndPoints.User.MakeUserHidden.Description)]
    public async Task<IActionResult> MakeUserHidden([Required] string userId) => MasaTourResponse(await Mediator.Send(new MakeUserHiddenByIdCommand(userId)));


    [HttpPatch(Router.User.MakeUserVisible)]
    [Authorize(Roles = $"{nameof(Roles.SuperAdmin)},{nameof(Roles.Admin)}")]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<dynamic>))]
    [SwaggerOperation(OperationId = EndPoints.User.MakeUserVisible.OperationId, Summary = EndPoints.User.MakeUserVisible.Summary, Description = EndPoints.User.MakeUserVisible.Description)]
    public async Task<IActionResult> MakeUserVisible([Required] string userId) => MasaTourResponse(await Mediator.Send(new MakeUserVisibleByIdCommand(userId)));
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
