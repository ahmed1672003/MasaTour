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
            // check name does not exist
            ISpecification<Category> getCategoryByNameArSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetCategoryByNameARSpecification), request.dto.NameAR);
            if (await _context.Categories.AnyAsync(getCategoryByNameArSpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<Category> getCategoryByNameDESpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetCategoryByNameDESpecification), request.dto.NameDE);
            if (await _context.Categories.AnyAsync(getCategoryByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<Category> getCategoryByNameENSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetCategoryByNameENSpecification), request.dto.NameEN);
            if (await _context.Categories.AnyAsync(getCategoryByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

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
            // check if category founded
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.dto.Id);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            // check duplicated anmeAR
            ISpecification<Category> asNoTrackingcheckDuplicatedNameArSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedCategoryByNameARSpecification), request.dto.Id, request.dto.NameAR);
            if (await _context.Categories.AnyAsync(asNoTrackingcheckDuplicatedNameArSpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check duplicated anmeDE
            ISpecification<Category> asNoTrackingcheckDuplicatedNameDESpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedCategoryByNameDESpecification), request.dto.Id, request.dto.NameDE);
            if (await _context.Categories.AnyAsync(asNoTrackingcheckDuplicatedNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check duplicated anmeEN
            ISpecification<Category> asNoTrackingcheckDuplicatedNameENSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedCategoryByNameENSpecification), request.dto.Id, request.dto.NameEN);
            if (await _context.Categories.AnyAsync(asNoTrackingcheckDuplicatedNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // select category
            ISpecification<Category> asTrackingGetCategoryByIdSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsTrackingGetCategoryByIdSpecification), request.dto.Id);
            Category category = await _context.Categories.RetrieveAsync(asTrackingGetCategoryByIdSpec, cancellationToken);

            category.NameAR = request.dto.NameAR;
            category.NameDE = request.dto.NameDE;
            category.NameDE = request.dto.NameDE;
            category.IsActive = request.dto.IsActive;

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
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.categoryId);

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
            ISpecification<Category> asNoTrackingGetDeletedCategoryByIdSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetDeletedCategoryByIdSpecification), request.categoryId);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetDeletedCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Category> asTrackingGetDeletedCategoryByIdSpec = _specificationsFactory.CreatCategorySpecifications(typeof(AsTrackingGetDeletedCategoryByIdSpecification), request.categoryId);
            Category category = await _context.Categories.RetrieveAsync(asTrackingGetDeletedCategoryByIdSpec, cancellationToken);



            _context.Categories.UndoDeleted(ref category);

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
