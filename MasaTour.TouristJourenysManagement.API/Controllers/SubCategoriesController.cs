namespace MasaTour.TouristTripsManagement.API.Controllers;

[ApiController]
public class SubCategoriesController : MasaTourController
{
    public SubCategoriesController(IMediator mediator) : base(mediator) { }

    #region Post
    [HttpPost(Router.SubCategory.AddSubCategory)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetSubCategoryDto>))]
    public async Task<IActionResult> AddSubCategory([FromBody] AddSubCategoryDto dto) =>
        MasaTourResponse(await Mediator.Send(new AddSubCategoryCommand(dto)));

    #endregion

    #region Put
    [HttpPut(Router.SubCategory.UpdateSubCategory)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetSubCategoryDto>))]
    public async Task<IActionResult> UpdateSubCategory([FromBody] UpdateSubCategoryDto dto) =>
        MasaTourResponse(await Mediator.Send(new UpdateSubCategoryCommand(dto)));

    #endregion

    #region Patch
    [HttpPatch(Router.SubCategory.DeleteSubCategoryById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetSubCategoryDto>))]
    public async Task<IActionResult> DeleteSubCategoryById([Required][MaxLength(36)][MinLength(36)] string subCategoryId) =>
        MasaTourResponse(await Mediator.Send(new DeleteSubCategoryCommand(subCategoryId)));



    [HttpPatch(Router.SubCategory.UndoDeleteSubCategoryById)]
    public async Task<IActionResult> UndoDeleteSubCategoryById([Required][MaxLength(36)][MinLength(36)] string subCategoryId) =>
        MasaTourResponse(await Mediator.Send(new UndoDeleteSubCategoryCommand(subCategoryId)));
    #endregion

    #region Get
    [HttpGet(Router.SubCategory.GetSubCategoryById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetSubCategoryDto>))]
    public async Task<IActionResult> GetSubCategoryById([Required][MaxLength(36)][MinLength(36)] string subCategoryId) =>
        MasaTourResponse(await Mediator.Send(new GetSubCategoryByIdQuery(subCategoryId)));



    [HttpGet(Router.SubCategory.GetAllSubCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetSubCategoryDto>>))]
    public async Task<IActionResult> GetAllSubCategories() =>
        MasaTourResponse(await Mediator.Send(new GetAllSubCategoriesQuery()));



    [HttpGet(Router.SubCategory.GetAllUnDeletedSubCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetSubCategoryDto>>))]
    public async Task<IActionResult> GetAllUnDeletedSubCategories() =>
        MasaTourResponse(await Mediator.Send(new GetAllUnDeletedSubCategoriesQuery()));



    [HttpGet(Router.SubCategory.GetAllDeletedSubCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetSubCategoryDto>>))]
    public async Task<IActionResult> GetAllDeletedSubCategories() =>
        MasaTourResponse(await Mediator.Send(new GetAllDeletedSubCategoriesQuery()));



    [HttpGet(Router.SubCategory.PaginateUnDeletedSubCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetSubCategoryDto>>))]
    public async Task<IActionResult> PaginateUnDeletedSubCategories(int? pageNumber = 1, int? pageSize = 1, string? keyWords = "", SubCategoryOrderBy? orderBy = SubCategoryOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PaginateUnDeletedSubCategoriesQuery(pageNumber, pageSize, keyWords, orderBy)));



    [HttpGet(Router.SubCategory.PaginateDeletedSubCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetSubCategoryDto>>))]
    public async Task<IActionResult> PaginateDeletedSubCategories(int? pageNumber = 1, int? pageSize = 01, string? keyWords = "", SubCategoryOrderBy? orderBy = SubCategoryOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PaginateDeletedSubCategoriesQuery(pageNumber, pageSize, keyWords, orderBy)));

    #endregion
}
