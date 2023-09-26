using MasaTour.TouristTripsManagement.Application.Features.Categories.Queries;
using MasaTour.TouristTripsManagement.Application.Features.Enums;

namespace MasaTour.TouristTripsManagement.API.Controllers;
//[Authorize(AuthenticationSchemes = "Bearer", Roles = $"{nameof(Roles.Admin)}")]
[ApiController]
public class CategoryController : MasaTourController
{
    public CategoryController(IMediator mediator) : base(mediator) { }

    #region Post
    [HttpPost(Router.Category.AddCategory)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetCategoryDto>))]
    [SwaggerOperation(OperationId = EndPoints.Category.AddCategory.OperationId, Summary = EndPoints.Category.AddCategory.Summary, Description = EndPoints.Category.AddCategory.Description)]
    public async Task<IActionResult> AddCategroy([FromBody] AddCategoryDto dto) => MasaTourResponse(await Mediator.Send(new AddCategoryCommand(dto)));
    #endregion

    #region Put
    [HttpPut(Router.Category.UpdateCategory)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetCategoryDto>))]
    [SwaggerOperation(OperationId = EndPoints.Category.UpdateCategory.OperationId, Summary = EndPoints.Category.UpdateCategory.Summary, Description = EndPoints.Category.UpdateCategory.Description)]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto) => MasaTourResponse(await Mediator.Send(new UpdateCategoryCommand(dto)));
    #endregion


    #region Patch
    [HttpPatch(Router.Category.DeleteCategoryById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetCategoryDto>))]
    [SwaggerOperation(OperationId = EndPoints.Category.DeleteCategoryById.OperationId, Summary = EndPoints.Category.DeleteCategoryById.Summary, Description = EndPoints.Category.DeleteCategoryById.Description)]
    public async Task<IActionResult> DeleteCategoryById([Required] string categoryId) => MasaTourResponse(await Mediator.Send(new DeleteCategoryByIdCommand(categoryId)));


    [HttpPatch(Router.Category.UndoDeleteCategoryById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetCategoryDto>))]
    [SwaggerOperation(OperationId = EndPoints.Category.UndoDeleteCategoryById.OperationId, Summary = EndPoints.Category.UndoDeleteCategoryById.Summary, Description = EndPoints.Category.UndoDeleteCategoryById.Description)]
    public async Task<IActionResult> UndoDeleteCategoryById([Required] string categoryId) => MasaTourResponse(await Mediator.Send(new UndoDeleteCategoryByIdCommand(categoryId)));
    #endregion

    #region Get 
    [AllowAnonymous]
    [HttpGet(Router.Category.GetCategoryById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetCategoryDto>>))]
    [SwaggerOperation(OperationId = EndPoints.Category.GetCategoryById.OperationId, Summary = EndPoints.Category.GetCategoryById.Summary, Description = EndPoints.Category.GetCategoryById.Description)]
    public async Task<IActionResult> GetCategoryById([Required] string categoryId) => MasaTourResponse(await Mediator.Send(new GetCategoryByIdQuery(categoryId)));


    [HttpGet(Router.Category.GetAllCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetCategoryDto>>))]
    [SwaggerOperation(OperationId = EndPoints.Category.GetAllCategories.OperationId, Summary = EndPoints.Category.GetAllCategories.Summary, Description = EndPoints.Category.GetAllCategories.Description)]
    public async Task<IActionResult> GetAllCategories() => MasaTourResponse(await Mediator.Send(new GetAllCategoriesQuery()));


    [HttpGet(Router.Category.GetAllDeletedCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetCategoryDto>>))]
    [SwaggerOperation(OperationId = EndPoints.Category.GetAllDeletedCategories.OperationId, Summary = EndPoints.Category.GetAllDeletedCategories.Summary, Description = EndPoints.Category.GetAllDeletedCategories.Description)]
    public async Task<IActionResult> GetAllDeletedCategories() => MasaTourResponse(await Mediator.Send(new GetAllDeletedCategoriesQuery()));


    [AllowAnonymous]
    [HttpGet(Router.Category.GetAllUnDeletedCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetCategoryDto>>))]
    [SwaggerOperation(OperationId = EndPoints.Category.GetAllUnDeletedCategories.OperationId, Summary = EndPoints.Category.GetAllUnDeletedCategories.Summary, Description = EndPoints.Category.GetAllUnDeletedCategories.Description)]
    public async Task<IActionResult> GetAllUnDeletedCategories() => MasaTourResponse(await Mediator.Send(new GetAllUnDeletedCategoriesQuery()));

    [AllowAnonymous]
    [HttpGet(Router.Category.GetAllActiveCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetCategoryDto>>))]
    [SwaggerOperation(OperationId = EndPoints.Category.GetAllActiveCategories.OperationId, Summary = EndPoints.Category.GetAllActiveCategories.Summary, Description = EndPoints.Category.GetAllActiveCategories.Description)]
    public async Task<IActionResult> GetAllActiveCategories() => MasaTourResponse(await Mediator.Send(new GetAllActiveCategoriesQuery()));


    [HttpGet(Router.Category.GetAllNotActiveCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetCategoryDto>>))]
    [SwaggerOperation(OperationId = EndPoints.Category.GetAllNotActiveCategories.OperationId, Summary = EndPoints.Category.GetAllNotActiveCategories.Summary, Description = EndPoints.Category.GetAllNotActiveCategories.Description)]
    public async Task<IActionResult> GetAllNotActiveCategories() => MasaTourResponse(await Mediator.Send(new GetAllNotActiveCategoriesQuery()));


    [AllowAnonymous]
    [HttpGet(Router.Category.PaginateCategories)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetCategoryDto>>))]
    [SwaggerOperation(OperationId = EndPoints.Category.PaginateCategories.OperationId, Summary = EndPoints.Category.PaginateCategories.Summary, Description = EndPoints.Category.PaginateCategories.Description)]
    public async Task<IActionResult> PaginateCategories(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", CategoryOrderBy? orderBy = CategoryOrderBy.CreatedAt) => MasaTourResponse(await Mediator.Send(new PaginateCategoriesQuery(pageNumber, pageSize, keyWords, orderBy)));
    #endregion
}
