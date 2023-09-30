using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Images;

namespace MasaTour.TouristTripsManagement.Application.Features.Images.Queries.Hander;
public sealed class ImagQueriesHandler :
    IRequestHandler<GetImageByIdQuery, ResponseModel<GetImageDto>>,
    IRequestHandler<GetAllImagesQuery, ResponseModel<IEnumerable<GetImageDto>>>,
    IRequestHandler<PaginateImagesQuery, PaginationResponseModel<IEnumerable<GetImageDto>>>
{
    #region Fileds
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    #endregion

    #region Ctor
    public ImagQueriesHandler(IMapper mapper, IUnitOfWork context, ISpecificationsFactory specificationsFactory, IStringLocalizer<SharedResources> stringLocalizer)
    {
        _mapper = mapper;
        _context = context;
        _specificationsFactory = specificationsFactory;
        _stringLocalizer = stringLocalizer;
    }

    #endregion

    #region Get By Id
    public async Task<ResponseModel<GetImageDto>> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Image> asNoTrackingGetImageByIdSpec = _specificationsFactory.CreateImageSpecifications(typeof(AsNoTrackingGetImageByIdSpecification), request.ImageId);

            if (!await _context.Images.AnyAsync(asNoTrackingGetImageByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetImageDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            GetImageDto imageDto = _mapper.Map<GetImageDto>(await _context.Images.RetrieveAsync(asNoTrackingGetImageByIdSpec, cancellationToken));

            return ResponseResult.Success(imageDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetImageDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All
    public async Task<ResponseModel<IEnumerable<GetImageDto>>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Images.AnyAsync(cancellationToken: cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetImageDto> imageDtos = _mapper.Map<IEnumerable<GetImageDto>>(await _context.Images.RetrieveAllAsync(cancellationToken: cancellationToken));

            return ResponseResult.Success(imageDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Paginate 
    public async Task<PaginationResponseModel<IEnumerable<GetImageDto>>> Handle(PaginateImagesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<Image, object>> orderBy = Image => new();

            switch (request.OrderBy)
            {
                case ImageOrderBy.ContetType:
                    orderBy = Image => Image.ContentType;
                    break;
                default:
                    orderBy = Image => Image.CreatedAt;
                    break;
            }

            ISpecification<Image> asNoTrackingPaginateImagesSpec = _specificationsFactory.CreateImageSpecifications(typeof(AsNoTrackingPaginateImagesSpecification), request.PageNumber, request.PageSize, orderBy);
            IEnumerable<GetImageDto> imageDtos = _mapper.Map<IEnumerable<GetImageDto>>(await _context.Images.RetrieveAllAsync(asNoTrackingPaginateImagesSpec, cancellationToken));
            return PaginationResponseResult.Success(imageDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success],
                                            pageSize: request.PageSize.Value, currentPage: request.PageNumber.Value, count: await _context.Images.CountAsync(cancellationToken: cancellationToken));
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetImageDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
