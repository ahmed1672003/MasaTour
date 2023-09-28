using MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;

namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Queries.Handler;
public sealed class SubCategoryQueriesHandler :
    IRequestHandler<GetSubCategoryByIdQuery, ResponseModel<GetSubCategoryDto>>,
    IRequestHandler<GetAllDeletedSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<GetAllSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<GetAllUnDeletedSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<PaginateDeletedSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<PaginateUnDeletedSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public SubCategoryQueriesHandler(
        IUnitOfWork context,
        IStringLocalizer<SharedResources> stringLocalizer,
        ISpecificationsFactory specificationsFactory,
        IMapper mapper)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _specificationsFactory = specificationsFactory;
        _mapper = mapper;
    }
    #endregion

    #region Get SubCategory By Id
    public async Task<ResponseModel<GetSubCategoryDto>> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByIdSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByIdSpecification), request.subCategoryId);
            if (!await _context.SubCategories.AnyAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            GetSubCategoryDto subCatgeoryDto = _mapper.Map<GetSubCategoryDto>(await _context.SubCategories.RetrieveAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken));
            return ResponseResult.Success<GetSubCategoryDto>(subCatgeoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Deleted SubCategories
    public Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All SubCategories
    public Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {

        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
    #region Get All UnDeleted SubCategories
    public Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllUnDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {

        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
    #region Paginate Deleted SubCategories 
    public Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(PaginateDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {

        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Pajinate UnDeleted SubCategories
    public Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(PaginateUnDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {

        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
