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
    /// Add Mandatory | Allowed For SuperAdmin Or Admin
    /// </summary>
    /// <param name="dto">البيانات المطلوبة لنجاح عملية الاضافة ,من فضلك التزم بشروط ادخال الحقول وعدد الحروف المسموح لكل حقل</param>
    /// <returns>المودل اللذي تمت أضافته في قاعدة البيانات</returns>
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
    /// </remarks>
    /// <response code="201">في حالة نجاح عملية الاضافة</response>
    /// <response code="403">في حالة عدم وجود صلاحية الوصول</response>
    /// <response code="401">في حالة عدم تسجيل الدخول</response>
    /// <response code="400">في حالة ادخال بيانات غير مطابقة للشروط وللتأكد من صحة البيانات قم بمراجعة الاسكيمة</response>       
    /// <response code="409">في حالة الاسم موجود من قبل</response>       
    /// <response code="500">في حالة حدوث خطأ في السيرفر, تأكد من صحة البيانات المدخلة وفي حالة حدوثه مرة أخري تواصل مع مطوري الخدمة</response>       
    [HttpPost(Router.Mandatory.AddMandatory)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<GetMandatoryDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(object))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(object))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseModel<object>))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ResponseModel<object>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseModel<object>))]
    [Produces(ContentTypes.ApplicationOverJson)]
    public async Task<IActionResult> AddMandatory([Required][FromBody] AddMandatoryDto dto) =>
            MasaTourResponse(await Mediator.Send(new AddMandatoryCommand(dto)));
    #endregion

    #region Put
    [HttpPut(Router.Mandatory.UpdateMandatory)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetMandatoryDto>))]
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
    [HttpGet(Router.Mandatory.GetMandatoryById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetMandatoryDto>))]
    public async Task<IActionResult> GetMandatoryById([Required][MaxLength(36)][MinLength(36)] string mandatoryId) =>
        MasaTourResponse(await Mediator.Send(new GetMandatoryByIdQuery(mandatoryId)));

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
