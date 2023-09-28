using MasaTour.TouristTripsManagement.Application.Features.Mandatories.Commands;
using MasaTour.TouristTripsManagement.Application.Features.Mandatories.Queries;
using MasaTour.TouristTripsManagement.Domain.Mandatories.Dtos;

namespace MasaTour.TouristTripsManagement.API.Controllers;

[ApiController]
public class MandatoryController : MasaTourController
{
    public MandatoryController(IMediator mediator) : base(mediator) { }

    #region Post
    [HttpPost(Router.Mandatory.AddMandatory)]
    public async Task<IActionResult> AddMandatory(AddMandatoryDto dto) => MasaTourResponse(await Mediator.Send(new AddMandatoryCommand(dto)));

    #endregion

    #region Put
    [HttpPut(Router.Mandatory.UpdateMandatory)]
    public async Task<IActionResult> UpdateMandatory(UpdateMandatoryDto dto) => MasaTourResponse(await Mediator.Send(new UpdateMandatoryCommand(dto)));
    #endregion

    #region Patch
    [HttpPatch(Router.Mandatory.DeleteMandatoryById)]
    public async Task<IActionResult> DeleteMandatoryById([Required][MaxLength(36)][MinLength(36)] string mandatoryId) => MasaTourResponse(await Mediator.Send(new DeleteMandatoryByIdCommand(mandatoryId)));


    [HttpPatch(Router.Mandatory.UndoDeleteMandatoryById)]
    public async Task<IActionResult> UndoDeleteMandatoryById([Required][MaxLength(36)][MinLength(36)] string mandatoryId) => MasaTourResponse(await Mediator.Send(new UndoDeleteMandatoryByIdCommand(mandatoryId)));
    #endregion


    #region Get
    [HttpGet(Router.Mandatory.GetMandatoryById)]
    public async Task<IActionResult> GetMandatoryById([Required][MaxLength(36)][MinLength(36)] string mandatoryId) => MasaTourResponse(await Mediator.Send(new GetMandatoryByIdQuery(mandatoryId)));

    [HttpGet(Router.Mandatory.GetAllMandatories)]
    public async Task<IActionResult> GetAllMandatories() => MasaTourResponse(await Mediator.Send(new GetAllMandatoriesQuery()));

    [HttpGet(Router.Mandatory.GetAllDeletedMandatories)]
    public async Task<IActionResult> GetAllDeletedMandatories() => MasaTourResponse(await Mediator.Send(new GetAllDeletedMandatoriesQuery()));


    [HttpGet(Router.Mandatory.GetAllUnDeletedMandatories)]
    public async Task<IActionResult> GetAllUnDeletedMandatories() => MasaTourResponse(await Mediator.Send(new GetAllUnDeletedMandatoriesQuery()));

    [HttpGet(Router.Mandatory.PaginateDeletedMandatories)]
    public async Task<IActionResult> PaginateDeletedMandatories(int? pageNumber = 1, int? pagSize = 10, string keyWords = "", MandatoryOrderBy? orderBy = MandatoryOrderBy.CreatedAt) => MasaTourResponse(await Mediator.Send(new PaginateDeletedMandatoriesQuery(pageNumber, pagSize, keyWords, orderBy)));

    [HttpGet(Router.Mandatory.PaginateUnDeletedMandatories)]
    public async Task<IActionResult> PaginateUnDeletedMandatories(int? pageNumber = 1, int? pagSize = 10, string keyWords = "", MandatoryOrderBy? orderBy = MandatoryOrderBy.CreatedAt) => MasaTourResponse(await Mediator.Send(new PaginateUnDeletedMandatoriesQuery(pageNumber, pagSize, keyWords, orderBy)));
    #endregion
}
