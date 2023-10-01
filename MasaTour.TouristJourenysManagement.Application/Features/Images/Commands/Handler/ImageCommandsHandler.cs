using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Images;

namespace MasaTour.TouristTripsManagement.Application.Features.Images.Commands.Handler;
public sealed class ImageCommandsHandler :
    IRequestHandler<AddImageCommand, ResponseModel<GetImageDto>>,
    IRequestHandler<DeleteImageCommand, ResponseModel<GetImageDto>>,
    IRequestHandler<AddImagesCommand, ResponseModel<IEnumerable<GetImageDto>>>,
    IRequestHandler<DeleteImagesCommand, ResponseModel<IEnumerable<GetImageDto>>>
{
    #region Fields
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IUnitOfServices _services;
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public ImageCommandsHandler(
        ISpecificationsFactory specificationsFactory,
        IUnitOfServices services,
        IUnitOfWork context,
        IStringLocalizer<SharedResources> stringLocalizer,
        IMapper mapper)
    {
        _specificationsFactory = specificationsFactory;
        _services = services;
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
    }
    #endregion

    #region Add Imaged 
    public async Task<ResponseModel<GetImageDto>> Handle(AddImageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _services.FileService.EnsureFileSize(request.File);
            _services.FileService.EnsureFileExctension(request.File);

            UploadFileResultDto uploadImageResult = await _services.FileService.UploadFileAsync(request.File, "Gellary");

            if (!uploadImageResult.Success)
                return ResponseResult.BadRequest<GetImageDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            Image img = new Image()
            {
                FileName = uploadImageResult.FileName,
                FilePath = uploadImageResult.FilePath,
                ContentType = uploadImageResult.ContentType,
            };
            await _context.Images.CreateAsync(img, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetImageDto imgDto = _mapper.Map<GetImageDto>(img);
            return ResponseResult.Created(imgDto, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetImageDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete Image
    public async Task<ResponseModel<GetImageDto>> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Image> asNoTrackingGetImageByIdSpec = _specificationsFactory.CreateImageSpecifications(typeof(AsNoTrackingGetImageByIdSpecification), request.Id);

            if (!await _context.Images.AnyAsync(asNoTrackingGetImageByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetImageDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            Image img = await _context.Images.RetrieveAsync(asNoTrackingGetImageByIdSpec, cancellationToken);

            await _context.Images.DeleteAsync(img, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            bool isDeletedSuccess = await _services.FileService.DeleteFileAsync("Gellary", img.FileName);

            if (!isDeletedSuccess)
                return ResponseResult.BadRequest<GetImageDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);
            GetImageDto imageDto = _mapper.Map<GetImageDto>(img);
            return ResponseResult.Success(imageDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetImageDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });

        }
    }
    #endregion

    #region Add Images
    public async Task<ResponseModel<IEnumerable<GetImageDto>>> Handle(AddImagesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            List<Image> images = new List<Image>();

            foreach (var file in request.Files)
            {
                UploadFileResultDto uploadImageResult = await _services.FileService.UploadFileAsync(file, "Gellary");

                if (!uploadImageResult.Success)
                    return ResponseResult.BadRequest<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

                images.Add(new Image()
                {
                    FileName = uploadImageResult.FileName,
                    FilePath = uploadImageResult.FilePath,
                    ContentType = uploadImageResult.ContentType,
                });
            }

            await _context.Images.CreateRangeAsync(images, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            IEnumerable<GetImageDto> imgDtos = _mapper.Map<IEnumerable<GetImageDto>>(images);
            return ResponseResult.Created(imgDtos, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete Images
    public async Task<ResponseModel<IEnumerable<GetImageDto>>> Handle(DeleteImagesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Images.AnyAsync(cancellationToken: cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);


            ISpecification<Image> asTrackingGetImagesByIdsSpec = _specificationsFactory.CreateImageSpecifications(typeof(AsTrackingGetImagesByIdsSpecification), request.ImagesIds);
            IQueryable<Image> images = await _context.Images.RetrieveAllAsync(asTrackingGetImagesByIdsSpec, cancellationToken);

            foreach (var image in images)
            {
                bool isDeletedSeccess = await _services.FileService.DeleteFileAsync("Gellary", image.FileName);
                await _context.Images.DeleteAsync(image, cancellationToken);
                if (!isDeletedSeccess)
                    return ResponseResult.BadRequest<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return ResponseResult.Success<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
