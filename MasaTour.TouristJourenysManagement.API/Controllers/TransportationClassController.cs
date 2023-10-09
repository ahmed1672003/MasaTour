using MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Commands;
using MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Dtos;
using MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Queries;

namespace MasaTour.TouristTripsManagement.API.Controllers;
/// <summary>
/// 
/// </summary>
[ApiController]
public class TransportationClassController : MasaTourController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public TransportationClassController(IMediator mediator) : base(mediator)
    {
    }

    #region Post
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Dto"></param>
    /// <returns></returns>
    [HttpPost(Router.TransportationClass.AddTransportationClass)]
    public async Task<IActionResult> AddTransportationClass(AddTransportationClassDto Dto) => MasaTourResponse(await Mediator.Send(new AddTransportationClassCommand(Dto)));

    #endregion

    #region Put
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Dto"></param>
    /// <returns></returns>
    [HttpPut(Router.TransportationClass.UpdateTransportationClass)]
    public async Task<IActionResult> UpdateTransportationClass(UpdateTransportationClassDto Dto) => MasaTourResponse(await Mediator.Send(new UpdateTransportationClassCommand(Dto)));
    #endregion

    #region Patch
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transportationClassId"></param>
    /// <returns></returns>

    [HttpPatch(Router.TransportationClass.DeleteTransportationClassById)]
    public async Task<IActionResult> DeleteTransportationClassById([Required][MaxLength(36)][MinLength(36)] string transportationClassId) => MasaTourResponse(await Mediator.Send(new DeleteTransportationClassByIdCommand(transportationClassId)));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="transportationClassId"></param>
    /// <returns></returns>

    [HttpPatch(Router.TransportationClass.UndoDeleteTransportationClassById)]
    public async Task<IActionResult> UndoDeleteTransportationClassById([Required][MaxLength(36)][MinLength(36)] string transportationClassId) => MasaTourResponse(await Mediator.Send(new UndoDeleteTransportationClassByIdCommand(transportationClassId)));

    #endregion

    #region Get
    /// <summary>
    /// 
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    [HttpGet(Router.TransportationClass.GetTransportationClassById)]
    public async Task<IActionResult> GetTransportationClassById([Required][MaxLength(36)][MinLength(36)] string classId) =>
        MasaTourResponse(await Mediator.Send(new GetTransportationClassByIdQuery(classId)));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.TransportationClass.GetAllTransportationClasses)]
    public async Task<IActionResult> GetAllTransportationClasses() =>
        MasaTourResponse(await Mediator.Send(new GetAllTransportationClassesQuery()));


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.TransportationClass.GetAllDeletedTransportationClasses)]
    public async Task<IActionResult> GetAllDeletedTransportationClasses() =>
        MasaTourResponse(await Mediator.Send(new GetAllDeletedTransportationClassesQuery()));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.TransportationClass.GetAllUnDeletedTransportationClasses)]
    public async Task<IActionResult> GetAllUnDeletedTransportationClasses() =>
        MasaTourResponse(await Mediator.Send(new GetAllUnDeletedTransportationClassesQuery()));


    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="keyWords"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>

    [HttpGet(Router.TransportationClass.PaginateDeletedTransportationClasses)]
    public async Task<IActionResult> PaginateDeletedTransportationClasses(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", TransportationClassOrderBy? orderBy = TransportationClassOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PginateDeletedTransportationClassesQuery(pageNumber, pageSize, keyWords, orderBy)));



    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="keyWords"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>

    [HttpGet(Router.TransportationClass.PaginateUnDeletedTransportationClasses)]
    public async Task<IActionResult> PaginateUnDeletedTransportationClasses(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", TransportationClassOrderBy? orderBy = TransportationClassOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PginateUnDeletedTransportationClassesQuery(pageNumber, pageSize, keyWords, orderBy)));
    #endregion
}
