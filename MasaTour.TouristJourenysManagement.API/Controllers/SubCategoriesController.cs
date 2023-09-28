using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Commands;
using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Dtos;

namespace MasaTour.TouristTripsManagement.API.Controllers;

[ApiController]
public class SubCategoriesController : MasaTourController
{
    public SubCategoriesController(IMediator mediator) : base(mediator) { }

    #region Post
    [HttpPost(Router.SubCategory.AddSubCategory)]
    public async Task<IActionResult> AddSubCategory([FromBody] AddSubCategoryDto dto) => MasaTourResponse(await Mediator.Send(new AddSubCategoryCommand(dto)));
    #endregion

    #region Put
    [HttpPut(Router.SubCategory.UpdateSubCategory)]
    public async Task<IActionResult> UpdateSubCategory([FromBody] UpdateSubCategoryDto dto) => MasaTourResponse(await Mediator.Send(new UpdateSubCategoryCommand(dto)));
    #endregion

    #region Patch
    [HttpPatch(Router.SubCategory.DeleteSubCategoryById)]
    public async Task<IActionResult> DeleteSubCategoryById([Required][MaxLength(36)][MinLength(36)] string subCategoryId) => MasaTourResponse(await Mediator.Send(new DeleteSubCategoryCommand(subCategoryId)));

    [HttpPatch(Router.SubCategory.UndoDeleteSubCategoryById)]
    public async Task<IActionResult> UndoDeleteSubCategoryById([Required][MaxLength(36)][MinLength(36)] string subCategoryId) => MasaTourResponse(await Mediator.Send(new UndoDeleteSubCategoryCommand(subCategoryId)));
    #endregion

    #region Get

    #endregion
}
