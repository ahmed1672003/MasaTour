using MasaTour.TouristTripsManagement.Application.Features.Mandatories.Commands;
using MasaTour.TouristTripsManagement.Application.Features.Mandatories.Queries;
using MasaTour.TouristTripsManagement.Domain.Mandatories.Dtos;

namespace MasaTour.TouristTripsManagement.API.Controllers;

[ApiController]
public class MandatoryController : MasaTourController
{
    public MandatoryController(IMediator mediator) : base(mediator) { }

    #region Post
    /// <summary>
    /// Add New Mandatory
    /// </summary>
    /// <param name="dto">Data required to send the request</param>
    /// <returns>Data added in the database</returns>
    /// <remarks>
    /// 
    /// Sample request:
    /// 
    ///     POST
    ///        {
    ///          "nameAR": "كريم واقي من الشمس",
    ///          "nameEN": "Sunscreen",
    ///          "nameDE": "Sonnencreme",
    ///          "desceiptionEN": null,
    ///          "desceiptionAR": null,
    ///          "desceiptionDE": null
    ///        }
    /// Warnings:
    /// 
    ///     (1) Duplicate name is not allowed 
    ///     (2) Images and mandatories are optional
    /// Access:
    ///         
    ///     (1) SuperAdmin
    ///     (2) Admin
    /// </remarks>
    /// <response code="201">In case the addition process is not successful</response>
    /// <response code="403">If there is no access</response>
    /// <response code="401">If you are not signed in</response>
    /// <response code="400">In the event of entering data that does not comply with the conditions, and to ensure the validity of the data, review the required data actors</response>       
    /// <response code="409">In case the name already exists, whether it is from any language</response>       
    /// <response code="500">In the event of an error in the server, make sure that the entered data is correct, and in case it occurs again, contact the service developers</response>       
    [HttpPost(Router.Mandatory.AddMandatory)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<GetMandatoryDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HttpStatusCode))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(HttpStatusCode))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel<>))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ResponseModel<>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseModel<>))]
    [Produces(ContentTypes.ApplicationOverJson)]
    public async Task<IActionResult> AddMandatory([Required][FromBody] AddMandatoryDto dto) =>
            MasaTourResponse(await Mediator.Send(new AddMandatoryCommand(dto)));
    #endregion

    #region Put
    /// <summary>
    /// Update mandatory
    /// </summary>
    /// <param name="dto">Data required to send the request</param>
    /// <returns>Data added in the database</returns>
    /// <remarks>
    /// 
    /// Sample request:
    /// 
    ///     UPDATE
    ///        {
    ///         "mandatoryId": "17EDB706-4AB0-4D3B-B608-B569301132C4",
    ///         "nameAR": "شال صحراوي",
    ///         "nameEN": "Desert Shawl",
    ///         "nameDE": "Wüsten-Schal",
    ///         "desceiptionEN": null,
    ///         "desceiptionAR": null,
    ///         "desceiptionDE": null
    ///        }
    /// Warnings:
    /// 
    ///     (1) Duplicate name is not allowed 
    /// Access:
    ///         
    ///     (1) SuperAdmin
    ///     (2) Admin
    /// </remarks>
    /// <response code="201">In case the addition process is not successful</response>
    /// <response code="403">If there is no access</response>
    /// <response code="401">If you are not signed in</response>
    /// <response code="404">If mandatory was not found in system</response>
    /// <response code="400">In the event of entering data that does not comply with the conditions, and to ensure the validity of the data, review the required data actors</response>       
    /// <response code="409">In case the name already exists, whether it is from any language</response>       
    /// <response code="500">In the event of an error in the server, make sure that the entered data is correct, and in case it occurs again, contact the service developers</response>       
    [HttpPut(Router.Mandatory.UpdateMandatory)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<GetMandatoryDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HttpStatusCode))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(HttpStatusCode))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel<>))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ResponseModel<>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseModel<>))]
    [Produces(ContentTypes.ApplicationOverJson)]
    public async Task<IActionResult> UpdateMandatory(UpdateMandatoryDto dto) =>
            MasaTourResponse(await Mediator.Send(new UpdateMandatoryCommand(dto)));
    #endregion

    #region Patch
    [HttpPatch(Router.Mandatory.DeleteMandatoryById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetMandatoryDto>))]
    public async Task<IActionResult> DeleteMandatoryById([Required][MaxLength(36)][MinLength(36)] string mandatoryId) =>
        MasaTourResponse(await Mediator.Send(new DeleteMandatoryByIdCommand(mandatoryId)));


    [HttpPatch(Router.Mandatory.UndoDeleteMandatoryById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetMandatoryDto>))]
    public async Task<IActionResult> UndoDeleteMandatoryById([Required][MaxLength(36)][MinLength(36)] string mandatoryId) =>
        MasaTourResponse(await Mediator.Send(new UndoDeleteMandatoryByIdCommand(mandatoryId)));
    #endregion


    #region Get
    /// <summary>
    /// Get mandatory by id
    /// </summary>
    /// <param name="mandatoryId">mandatory id</param>
    /// <returns></returns>
    /// /// <remarks>
    /// Warnings:
    /// 
    ///     (1) Duplicate name is not allowed 
    ///     (2) Images and mandatories are optional
    /// Access:
    ///         
    ///       Anonymous
    /// </remarks>
    /// <response code="200">In case the addition process is not successful</response>
    /// <response code="403">If there is no access</response>
    /// <response code="401">If you are not signed in</response>
    /// <response code="500">In the event of an error in the server, make sure that the entered data is correct, and in case it occurs again, contact the service developers</response>       
    [HttpGet(Router.Mandatory.GetMandatoryById)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<GetMandatoryDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(HttpStatusCode))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(HttpStatusCode))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseModel<>))]
    [Produces(ContentTypes.ApplicationOverJson)]
    public async Task<IActionResult> GetMandatoryById([Required][MaxLength(36)][MinLength(36)] string mandatoryId) =>
        MasaTourResponse(await Mediator.Send(new GetMandatoryByIdQuery(mandatoryId)));



    /// <summary>
    /// Get all deleted mandatories and undeleted mandatories
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// 
    /// </remarks>
    [HttpGet(Router.Mandatory.GetAllMandatories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetMandatoryDto>>))]
    public async Task<IActionResult> GetAllMandatories() =>
        MasaTourResponse(await Mediator.Send(new GetAllMandatoriesQuery()));


    [HttpGet(Router.Mandatory.GetAllDeletedMandatories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetMandatoryDto>>))]
    public async Task<IActionResult> GetAllDeletedMandatories() =>
        MasaTourResponse(await Mediator.Send(new GetAllDeletedMandatoriesQuery()));


    [HttpGet(Router.Mandatory.GetAllUnDeletedMandatories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetMandatoryDto>>))]
    public async Task<IActionResult> GetAllUnDeletedMandatories() =>
        MasaTourResponse(await Mediator.Send(new GetAllUnDeletedMandatoriesQuery()));


    [HttpGet(Router.Mandatory.PaginateDeletedMandatories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetMandatoryDto>>))]
    public async Task<IActionResult> PaginateDeletedMandatories(int? pageNumber = 1, int? pagSize = 10, string keyWords = "", MandatoryOrderBy? orderBy = MandatoryOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PaginateDeletedMandatoriesQuery(pageNumber, pagSize, keyWords, orderBy)));



    [HttpGet(Router.Mandatory.PaginateUnDeletedMandatories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetMandatoryDto>>))]
    public async Task<IActionResult> PaginateUnDeletedMandatories(int? pageNumber = 1, int? pagSize = 10, string keyWords = "", MandatoryOrderBy? orderBy = MandatoryOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PaginateUnDeletedMandatoriesQuery(pageNumber, pagSize, keyWords, orderBy)));
    #endregion
}
