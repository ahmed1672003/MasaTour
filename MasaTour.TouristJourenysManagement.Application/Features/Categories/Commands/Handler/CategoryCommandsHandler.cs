namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Commands.Handler;
public sealed class CategoryCommandsHandler :
    IRequestHandler<AddCategoryCommand, ResponseModel<GetCategoryDto>>,
    IRequestHandler<UpdateCategoryCommand, ResponseModel<GetCategoryDto>>,
    IRequestHandler<DeleteCategoryByIdCommand, ResponseModel<GetCategoryDto>>,
    IRequestHandler<UndoDeleteCategoryByIdCommand, ResponseModel<GetCategoryDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public CategoryCommandsHandler(
      IUnitOfWork context,
      ISpecificationsFactory specificationsFactory,
      IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer)
    {
        _context = context;
        _specificationsFactory = specificationsFactory;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }
    #endregion

    #region Add Category
    public async Task<ResponseModel<GetCategoryDto>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // check nameAR does not exist in UnDeleted Categories
            ISpecification<Category> getCategoryByNameArSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByNameARSpecification), request.dto.NameAR);
            if (await _context.Categories.AnyAsync(getCategoryByNameArSpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check nameAR does not exist in UnDeleted Categories
            ISpecification<Category> getCategoryByNameDESpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByNameDESpecification), request.dto.NameDE);
            if (await _context.Categories.AnyAsync(getCategoryByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check nameEN does not exist in UnDeleted Categories
            ISpecification<Category> getCategoryByNameENSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByNameENSpecification), request.dto.NameEN);
            if (await _context.Categories.AnyAsync(getCategoryByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check nameAR does not exist in Deleted Categories
            ISpecification<Category> asNoTrackingGetDeletedCategoryByNameARSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetDeletedCategoryByNameARSpecification), request.dto.NameAR);
            if (await _context.Categories.AnyAsync(asNoTrackingGetDeletedCategoryByNameARSpec, cancellationToken))
                return ResponseResult.Conflict<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // check nameEN does not exist in Deleted Categories
            ISpecification<Category> asNoTrackingGetDeletedCategoryByNameENSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetDeletedCategoryByNameENSpecification), request.dto.NameEN);
            if (await _context.Categories.AnyAsync(asNoTrackingGetDeletedCategoryByNameENSpec, cancellationToken))
                return ResponseResult.Conflict<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // check nameDE does not exist in Deleted Categories
            ISpecification<Category> asNoTrackingGetDeletedCategoryByNameDESpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetDeletedCategoryByNameDESpecification), request.dto.NameDE);
            if (await _context.Categories.AnyAsync(asNoTrackingGetDeletedCategoryByNameDESpec, cancellationToken))
                return ResponseResult.Conflict<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            Category category = _mapper.Map<Category>(request.dto);

            await _context.Categories.CreateAsync(category);
            await _context.SaveChangesAsync();

            GetCategoryDto categoryDto = _mapper.Map<GetCategoryDto>(category);

            return ResponseResult.Created(categoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Update Category
    public async Task<ResponseModel<GetCategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // check if category founded by id
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.dto.CategoryId);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            // check duplicated nmeAR in UnDeleted Categories
            ISpecification<Category> asNoTrackingcheckDuplicatedNameArSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedCategoryByNameARSpecification), request.dto.CategoryId, request.dto.NameAR);
            if (await _context.Categories.AnyAsync(asNoTrackingcheckDuplicatedNameArSpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check duplicated nmeDE in UnDeleted Categories
            ISpecification<Category> asNoTrackingcheckDuplicatedNameDESpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedCategoryByNameDESpecification), request.dto.CategoryId, request.dto.NameDE);
            if (await _context.Categories.AnyAsync(asNoTrackingcheckDuplicatedNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check duplicated nmeEN in UnDeleted Categories
            ISpecification<Category> asNoTrackingcheckDuplicatedNameENSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedCategoryByNameENSpecification), request.dto.CategoryId, request.dto.NameEN);
            if (await _context.Categories.AnyAsync(asNoTrackingcheckDuplicatedNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check duplicated nmeAR in Deleted Categories
            ISpecification<Category> asNoTrackingCheckDuplicatedDeletedCategoryByNameARSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedCategoryByNameARSpecification), request.dto.CategoryId, request.dto.NameAR);
            if (await _context.Categories.AnyAsync(asNoTrackingCheckDuplicatedDeletedCategoryByNameARSpec, cancellationToken))
                return ResponseResult.Conflict<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // check duplicated nmeEN in Deleted Categories
            ISpecification<Category> asNoTrackingCheckDuplicatedDeletedCategoryByNameENSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedCategoryByNameENSpecification), request.dto.CategoryId, request.dto.NameEN);
            if (await _context.Categories.AnyAsync(asNoTrackingCheckDuplicatedDeletedCategoryByNameENSpec, cancellationToken))
                return ResponseResult.Conflict<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // check duplicated nmeDE in Deleted Categories
            ISpecification<Category> asNoTrackingCheckDuplicatedDeletedCategoryByNameDESpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedCategoryByNameDESpecification), request.dto.CategoryId, request.dto.NameDE);
            if (await _context.Categories.AnyAsync(asNoTrackingCheckDuplicatedDeletedCategoryByNameDESpec, cancellationToken))
                return ResponseResult.Conflict<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // select category
            ISpecification<Category> asTrackingGetCategoryByIdSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsTrackingGetCategoryByIdSpecification), request.dto.CategoryId);
            Category category = await _context.Categories.RetrieveAsync(asTrackingGetCategoryByIdSpec, cancellationToken);

            category.NameAR = request.dto.NameAR;
            category.NameDE = request.dto.NameDE;
            category.NameDE = request.dto.NameDE;
            // category.IsActive = request.dto.IsActive;

            await _context.SaveChangesAsync(cancellationToken);

            GetCategoryDto categoryDto = _mapper.Map<GetCategoryDto>(category);

            return ResponseResult.Success(categoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete Category
    public async Task<ResponseModel<GetCategoryDto>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.categoryId);

            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            Category category = await _context.Categories.RetrieveAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken);
            await _context.Categories.DeleteAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetCategoryDto categoryDto = _mapper.Map<GetCategoryDto>(category);
            return ResponseResult.Success(categoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Undo Delete Category
    public async Task<ResponseModel<GetCategoryDto>> Handle(UndoDeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Category> asNoTrackingGetDeletedCategoryByIdSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetDeletedCategoryByIdSpecification), request.categoryId);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetDeletedCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Category> asTrackingGetDeletedCategoryById_SubCategories_Trips_Spec = _specificationsFactory.CreateCategorySpecifications(typeof(AsTrackingGetDeletedCategoryById_SubCategories_Trips_Specification), request.categoryId);
            Category category = await _context.Categories.RetrieveAsync(asTrackingGetDeletedCategoryById_SubCategories_Trips_Spec, cancellationToken);

            _context.UndoDeleted(ref category);

            category.SubCategories.ForEach(subCategory =>
            {
                subCategory.Trips.ForEach(trip =>
                {
                    _context.UndoDeleted(ref trip);
                });
                _context.UndoDeleted(ref subCategory);
            });

            await _context.SaveChangesAsync(cancellationToken);

            GetCategoryDto categoryDto = _mapper.Map<GetCategoryDto>(category);

            return ResponseResult.Success(categoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);

        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
