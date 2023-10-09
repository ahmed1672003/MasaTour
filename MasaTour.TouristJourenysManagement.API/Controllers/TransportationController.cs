
using MasaTour.TouristTripsManagement.Application.Features.Transportations.Queries;

namespace MasaTour.TouristTripsManagement.API.Controllers;
/// <summary>
/// 
/// </summary>
[ApiController]
public class TransportationController : MasaTourController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public TransportationController(IMediator mediator) : base(mediator)
    {
    }


    #region Post
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Dto"></param>
    /// <returns></returns>
    [HttpPost(Router.Transportation.AddTransportation)]
    public async Task<IActionResult> AddTransportation(AddTransportationDto Dto) =>
        MasaTourResponse(await Mediator.Send(new AddTransportationCommand(Dto)));
    #endregion

    #region Put
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Dto"></param>
    /// <returns></returns>
    [HttpPut(Router.Transportation.UpdateTransportation)]
    public async Task<IActionResult> UpdateTransportation(UpdateTransportationDto Dto) =>
        MasaTourResponse(await Mediator.Send(new UpdateTransportationCommand(Dto)));
    #endregion

    #region Patch
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transportationId"></param>
    /// <returns></returns>
    [HttpPatch(Router.Transportation.DeleteTransportationById)]
    public async Task<IActionResult> DeleteTransportationById([Required][MaxLength(36)][MinLength(36)] string transportationId) =>
        MasaTourResponse(await Mediator.Send(new DeleteTransportationByIdCommand(transportationId)));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="transportationId"></param>
    /// <returns></returns>
    [HttpPatch(Router.Transportation.UndoDeleteTransportationById)]
    public async Task<IActionResult> UndoDeleteTransportationById([Required][MaxLength(36)][MinLength(36)] string transportationId) =>
        MasaTourResponse(await Mediator.Send(new UndoDeleteTransportationByIdCommand(transportationId)));
    #endregion

    #region Get

    /// <summary>
    /// 
    /// </summary>
    /// <param name="transportationId"></param>
    /// <returns></returns>
    [HttpGet(Router.Transportation.GetTransportationById)]
    public async Task<IActionResult> GetTransportationById([Required][MaxLength(36)][MinLength(36)] string transportationId) =>
       MasaTourResponse(await Mediator.Send(new GetTransportationByIdQuery(transportationId)));


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.Transportation.GetAllTransportations)]
    public async Task<IActionResult> GetAllTransportations() =>
       MasaTourResponse(await Mediator.Send(new GetAllTransportationsQuery()));



    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.Transportation.GetAllDeletedTransportations)]
    public async Task<IActionResult> GetAllDeletedTransportationes() =>
       MasaTourResponse(await Mediator.Send(new GetAllDeletedTransportationsQuery()));


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.Transportation.GetAllUnDeletedTransportations)]
    public async Task<IActionResult> GetAllUnDeletedTransportations() =>
       MasaTourResponse(await Mediator.Send(new GetAllUnDeletedTransportationsQuery()));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="keyWords"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    [HttpGet(Router.Transportation.PaginateDeletedTransportations)]
    public async Task<IActionResult> PaginateDeletedTransportations(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", TransportationOrderBy? orderBy = TransportationOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PaginateDeletedTransportationsQuery(pageNumber, pageSize, keyWords, orderBy)));


    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="keyWords"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    [HttpGet(Router.Transportation.PaginateUnDeletedTransportations)]
    public async Task<IActionResult> PaginateUnDeletedTransportations(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", TransportationOrderBy? orderBy = TransportationOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PaginateUnDeletedTransportationsQuery(pageNumber, pageSize, keyWords, orderBy)));
    #endregion
}
