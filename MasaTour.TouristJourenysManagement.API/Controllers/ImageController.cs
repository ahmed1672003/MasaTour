using MasaTour.TouristTripsManagement.Application.Features.Images.Commands;
using MasaTour.TouristTripsManagement.Application.Features.Images.Queries;
using MasaTour.TouristTripsManagement.Services.Services.Contracts;

namespace MasaTour.TouristTripsManagement.API.Controllers;
[ApiController]
public class ImageController : MasaTourController
{
    private readonly IUnitOfServices _services;
    public ImageController(IMediator mediator) : base(mediator)
    {
    }


    #region Post
    /// <summary>
    /// Add Image To Gellary
    /// </summary>
    /// <param name="image">File</param>
    /// <returns></returns>
    /// <remarks>
    /// Allowed Extensions: 
    /// 
    ///         [".png",".jpg",".jpeg",".gif",".bmp",".tiff",".tif",".svg",".webp",".heic"]
    /// Maxe Size : 
    /// 
    ///     3MB
    /// </remarks>
    [HttpPost(Router.Image.AddImage)]
    public async Task<IActionResult> AddImage([Required] IFormFile image) => MasaTourResponse(await Mediator.Send(new AddImageCommand(image)));

    /// <summary>
    /// Add Collection Of Images To Gellary
    /// </summary>
    /// <remarks>
    /// Allowed Extensions: 
    /// 
    /// [".png",".jpg",".jpeg",".gif",".bmp",".tiff",".tif",".svg",".webp",".heic"],
    /// Maxe Size :
    ///     
    /// 3MB
    /// </remarks>
    /// <param name="images">Files</param>
    /// <returns></returns>
    [HttpPost(Router.Image.AddImages)]
    public async Task<IActionResult> AddImages([Required] IEnumerable<IFormFile> images) => MasaTourResponse(await Mediator.Send(new AddImagesCommand(images)));

    #endregion

    #region Get
    /// <summary>
    /// Get Image From Gellaey
    /// </summary>
    /// <param name="imageId">ImageId</param>
    /// <returns></returns>
    [HttpGet(Router.Image.GetImageById)]
    public async Task<IActionResult> GetImageById([Required][MaxLength(36)][MinLength(36)] string imageId) => MasaTourResponse(await Mediator.Send(new GetImageByIdQuery(imageId)));

    /// <summary>
    /// Get All Images From Gellary
    /// </summary>
    /// <returns></returns>
    [HttpGet(Router.Image.GetAllImages)]
    public async Task<IActionResult> GetAllImages() => MasaTourResponse(await Mediator.Send(new GetAllImagesQuery()));

    /// <summary>
    /// Paginate Gellary
    /// </summary>
    /// <param name="pageNumber">Page You Need To Go</param>
    /// <param name="pageSize">Number Of Images You Need To Show In Page</param>
    /// <param name="orderBy">ContetType[0] , CreatedAt[1]</param>
    /// <returns></returns>
    [HttpGet(Router.Image.PaginateImages)]
    public async Task<IActionResult> PaginateImages(int? pageNumber = 1, int? pageSize = 10, ImageOrderBy? orderBy = ImageOrderBy.CreatedAt) => MasaTourResponse(await Mediator.Send(new PaginateImagesQuery(pageNumber, pageSize, orderBy)));
    #endregion

    #region Delete
    /// <summary>
    /// Delete Image From Gellary
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpDelete(Router.Image.DeleteImage)]
    public async Task<IActionResult> DeleteImage([Required][MaxLength(36)][MinLength(36)] string Id) => MasaTourResponse(await Mediator.Send(new DeleteImageCommand(Id)));

    /// <summary>
    /// Delete Collection Of Images
    /// </summary>
    /// <param name="imagesIds">List Of Images Ids You Need To Delete</param>
    /// <returns></returns>
    [HttpDelete(Router.Image.DeleteImages)]
    public async Task<IActionResult> DeleteImages([FromBody] List<string> imagesIds) => MasaTourResponse(await Mediator.Send(new DeleteImagesCommand(imagesIds)));
    #endregion
}
