using System.Linq.Expressions;

using MasaTour.TouristJourenysManagement.Application.Features.Enums;

namespace MasaTour.TouristJourenysManagement.Application.Features.Categories.Queries.Handler;
public sealed class CategoryQueriesHandler :
    IRequestHandler<GetCategoryByIdQuery, ResponseModel<GetCategoryDto>>,
    IRequestHandler<GetAllCategoriesQuery, ResponseModel<IEnumerable<GetCategoryDto>>>,
    IRequestHandler<PaginateCategoriesQuery, PaginationResponseModel<IEnumerable<GetCategoryDto>>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public CategoryQueriesHandler(
    IUnitOfWork context,
    ISpecificationsFactory specificationsFactory,
    IStringLocalizer<SharedResources> stringLocalizer,
    IMapper mapper
        )
    {
        _context = context;
        _specificationsFactory = specificationsFactory;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
    }
    #endregion

    #region Get Gategory By Id
    public async Task<ResponseModel<GetCategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.categoryId);

            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            GetCategoryDto categoryDto = _mapper.Map<GetCategoryDto>(await _context.Categories.RetrieveAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken));

            return ResponseResult.Success(categoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Categories
    public async Task<ResponseModel<IEnumerable<GetCategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Categories.AnyAsync(cancellationToken: cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetCategoryDto> categoriesDto = _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(cancellationToken: cancellationToken));
            return ResponseResult.Success(categoriesDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Pagination Categories
    public async Task<PaginationResponseModel<IEnumerable<GetCategoryDto>>> Handle(PaginateCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Categories.AnyAsync(cancellationToken: cancellationToken))
                return PaginationResponseResult.NotFound<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            Expression<Func<Category, object>> orderBy = category => new();

            switch (request.orderBy)
            {
                case CategoryOrderBy.Id:
                    orderBy = category => category.Id;
                    break;
                case CategoryOrderBy.NameAR:
                    orderBy = category => category.NameAR;
                    break;
                case CategoryOrderBy.NameEN:
                    orderBy = category => category.NameEN;
                    break;
                case CategoryOrderBy.NameDE:
                    orderBy = category => category.NameDE;
                    break;
                default:
                    orderBy = category => category.CreatedAt;
                    break;
            }
            ISpecification<Category> asNoTrackingPaginateCategoriesSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingPaginateCategoriesSpecification), request.pageNumber!.Value, request.pageSize!.Value, orderBy);
            IEnumerable<GetCategoryDto> categoriesDto = _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(asNoTrackingPaginateCategoriesSpec, cancellationToken));
            return PaginationResponseResult.Success(categoriesDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
