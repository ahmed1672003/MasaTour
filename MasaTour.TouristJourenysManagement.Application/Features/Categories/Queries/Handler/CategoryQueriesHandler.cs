﻿namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Queries.Handler;
public sealed class CategoryQueriesHandler :
    IRequestHandler<GetCategoryByIdQuery, ResponseModel<GetCategoryDto>>,
    IRequestHandler<GetAllCategoriesQuery, ResponseModel<IEnumerable<GetCategoryDto>>>,
    IRequestHandler<GetAllDeletedCategoriesQuery, ResponseModel<IEnumerable<GetCategoryDto>>>,
    IRequestHandler<GetAllUnDeletedCategoriesQuery, ResponseModel<IEnumerable<GetCategoryDto>>>,
    IRequestHandler<PaginateUnDeletedCategoriesQuery, PaginationResponseModel<IEnumerable<GetCategoryDto>>>,
    IRequestHandler<PaginateDeletedCategoriesQuery, PaginationResponseModel<IEnumerable<GetCategoryDto>>>
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
    IMapper mapper)
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
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.categoryId);

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
            ISpecification<Category> asNoTrackingGetAllCategoriesSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetAllCategoriesSpecification));
            if (!await _context.Categories.AnyAsync(asNoTrackingGetAllCategoriesSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetCategoryDto> categoriesDto = _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(asNoTrackingGetAllCategoriesSpec, cancellationToken));
            return ResponseResult.Success(categoriesDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Deleted Categories
    public async Task<ResponseModel<IEnumerable<GetCategoryDto>>> Handle(GetAllDeletedCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetDeletedCategorySpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetAllDeletedCategoriesSpecification));
            if (!await _context.Categories.AnyAsync(asNoTrackingGetDeletedCategorySpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetCategoryDto> categoriesDto = _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(asNoTrackingGetDeletedCategorySpec, cancellationToken));
            return ResponseResult.Success(categoriesDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All UnDeleted Categories
    public async Task<ResponseModel<IEnumerable<GetCategoryDto>>> Handle(GetAllUnDeletedCategoriesQuery request, CancellationToken cancellationToken)
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

    #region Pagination UnDeleted Categories
    public async Task<PaginationResponseModel<IEnumerable<GetCategoryDto>>> Handle(PaginateUnDeletedCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
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

            ISpecification<Category> asNoTrackingPaginateCategoriesSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingPaginateUnDeletedCategoriesSpecification), request.pageNumber!.Value, request.pageSize!.Value, request.keyWords, orderBy);
            IEnumerable<GetCategoryDto> categoriesDto = _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(asNoTrackingPaginateCategoriesSpec, cancellationToken));
            return PaginationResponseResult.Success(categoriesDto, count: await _context.Categories.CountAsync(cancellationToken: cancellationToken), currentPage: request.pageNumber.Value, pageSize: request.pageSize.Value, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Pagination Deleted Categories
    public async Task<PaginationResponseModel<IEnumerable<GetCategoryDto>>> Handle(PaginateDeletedCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
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

            ISpecification<Category> asNoTrackingGetAllDeletedCategoriesSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetAllDeletedCategoriesSpecification));
            ISpecification<Category> asNoTrackingPaginateDeletedCategoriesSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingPaginateDeletedCategoriesSpecification), request.pageNumber!.Value, request.pageSize!.Value, request.keyWords, orderBy);
            IEnumerable<GetCategoryDto> categoriesDto = _mapper.Map<IEnumerable<GetCategoryDto>>(await _context.Categories.RetrieveAllAsync(asNoTrackingPaginateDeletedCategoriesSpec, cancellationToken));
            return PaginationResponseResult.Success(categoriesDto, count: await _context.Categories.CountAsync(asNoTrackingGetAllDeletedCategoriesSpec, cancellationToken), currentPage: request.pageNumber.Value, pageSize: request.pageSize.Value, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetCategoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
