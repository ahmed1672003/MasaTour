using MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;

namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Queries.Handler;
public sealed class SubCategoryQueriesHandler :
    IRequestHandler<GetSubCategoryByIdQuery, ResponseModel<GetSubCategoryDto>>,
    IRequestHandler<GetAllDeletedSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<GetAllSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<GetAllUnDeletedSubCategoriesQuery, ResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<PaginateDeletedSubCategoriesQuery, PaginationResponseModel<IEnumerable<GetSubCategoryDto>>>,
    IRequestHandler<PaginateUnDeletedSubCategoriesQuery, PaginationResponseModel<IEnumerable<GetSubCategoryDto>>>
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
    public async Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetAllDeletedSubCategoriesSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetAllDeletedSubCategoriesSpecification));
            if (!await _context.SubCategories.AnyAsync(asNoTrackingGetAllDeletedSubCategoriesSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetSubCategoryDto> subCategoryDtos = _mapper.Map<IEnumerable<GetSubCategoryDto>>(await _context.SubCategories.RetrieveAllAsync(asNoTrackingGetAllDeletedSubCategoriesSpec, cancellationToken));
            return ResponseResult.Success(subCategoryDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All SubCategories
    public async Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetAllSubCategoriesSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetAllSubCategoriesSpecification));
            if (!await _context.SubCategories.AnyAsync(asNoTrackingGetAllSubCategoriesSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetSubCategoryDto> subCategoryDtos = _mapper.Map<IEnumerable<GetSubCategoryDto>>(await _context.SubCategories.RetrieveAllAsync(asNoTrackingGetAllSubCategoriesSpec, cancellationToken));
            return ResponseResult.Success(subCategoryDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All UnDeleted SubCategories
    public async Task<ResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(GetAllUnDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.SubCategories.AnyAsync(cancellationToken: cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);
            IEnumerable<GetSubCategoryDto> subCategoryDtos = _mapper.Map<IEnumerable<GetSubCategoryDto>>(await _context.SubCategories.RetrieveAllAsync(cancellationToken: cancellationToken));
            return ResponseResult.Success(subCategoryDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Paginate Deleted SubCategories 
    public async Task<PaginationResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(PaginateDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<SubCategory, object>> orderBy = subCategory => new();
            switch (request.orderBy)
            {
                case SubCategoryOrderBy.Id:
                    orderBy = subCategory => subCategory.Id;
                    break;
                case SubCategoryOrderBy.NameAR:
                    orderBy = subCategory => subCategory.NameAR;
                    break;
                case SubCategoryOrderBy.NameEN:
                    orderBy = subCategory => subCategory.NameEN;
                    break;
                case SubCategoryOrderBy.NameDE:
                    orderBy = subCategory => subCategory.NameDE;
                    break;
                default:
                    orderBy = subCategory => subCategory.CreatedAt;
                    break;
            }
            ISpecification<SubCategory> asNoTrackingPaginateDeletedSubCategoriesSpec = _specificationsFactory.
                CreateSubCategorySpecifications(typeof(AsNoTrackingPaginateDeletedSubCategoriesSpecification), request.pageNumber, request.pageSize, request.keyWords, orderBy);

            IEnumerable<GetSubCategoryDto> subCategoryDtos = _mapper.Map<IEnumerable<GetSubCategoryDto>>(await _context.SubCategories.RetrieveAllAsync(asNoTrackingPaginateDeletedSubCategoriesSpec, cancellationToken));

            ISpecification<SubCategory> asNoTrackingGetAllDeletedSubCategoriesSpec = _specificationsFactory.
                                   CreateSubCategorySpecifications(typeof(AsNoTrackingGetAllDeletedSubCategoriesSpecification));

            return PaginationResponseResult.Success(subCategoryDtos, currentPage: request.pageNumber.Value, pageSize: request.pageSize.Value, count: await _context.SubCategories.CountAsync(asNoTrackingGetAllDeletedSubCategoriesSpec, cancellationToken), message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Paginate UnDeleted SubCategories
    public async Task<PaginationResponseModel<IEnumerable<GetSubCategoryDto>>> Handle(PaginateUnDeletedSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<SubCategory, object>> orderBy = subCategory => new();
            switch (request.orderBy)
            {
                case SubCategoryOrderBy.Id:
                    orderBy = subCategory => subCategory.Id;
                    break;
                case SubCategoryOrderBy.NameAR:
                    orderBy = subCategory => subCategory.NameAR;
                    break;
                case SubCategoryOrderBy.NameEN:
                    orderBy = subCategory => subCategory.NameEN;
                    break;
                case SubCategoryOrderBy.NameDE:
                    orderBy = subCategory => subCategory.NameDE;
                    break;
                default:
                    orderBy = subCategory => subCategory.CreatedAt;
                    break;
            }
            ISpecification<SubCategory> asNoTrackingPaginateUnDeletedSubCategoriesSpec = _specificationsFactory.
                                CreateSubCategorySpecifications(typeof(AsNoTrackingPaginateUnDeletedSubCategoriesSpecification),
                                        request.pageNumber.Value, request.pageSize.Value, request.keyWords, orderBy);

            IEnumerable<GetSubCategoryDto> subCategoryDtos = _mapper.Map<IEnumerable<GetSubCategoryDto>>(await _context.SubCategories.RetrieveAllAsync(asNoTrackingPaginateUnDeletedSubCategoriesSpec, cancellationToken));
            return PaginationResponseResult.Success(subCategoryDtos, currentPage: request.pageNumber.Value, pageSize: request.pageSize.Value, count: await _context.SubCategories.CountAsync(cancellationToken: cancellationToken), message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetSubCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
