using MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;

namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Commands.Handler;
public sealed class SubCategoryCommandsHandler :
    IRequestHandler<AddSubCategoryCommand, ResponseModel<GetSubCategoryDto>>,
    IRequestHandler<UpdateSubCategoryCommand, ResponseModel<GetSubCategoryDto>>,
    IRequestHandler<DeleteSubCategoryCommand, ResponseModel<GetSubCategoryDto>>,
    IRequestHandler<UndoDeleteSubCategoryCommand, ResponseModel<GetSubCategoryDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public SubCategoryCommandsHandler(
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

    #region Add SubCategory
    public async Task<ResponseModel<GetSubCategoryDto>> Handle(AddSubCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Category Shold Be Is Exist
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.dto.CategoryId);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken))
                return ResponseResult.BadRequest<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // UnDeleted SubCategory NameAR Should Be Does Not Exist
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByNameARSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByNameARSpecification), request.dto.NameAR);
            if (await _context.SubCategories.AnyAsync(asNoTrackingGetSubCategoryByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // UnDeleted SubCategory NameEN Should Be Does Not Exist
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByNameENSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByNameENSpecification), request.dto.NameEN);
            if (await _context.SubCategories.AnyAsync(asNoTrackingGetSubCategoryByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // UnDeleted SubCategory NameDE Should Be Does Not Exist
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByNameDESpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByNameDESpecification), request.dto.NameDE);
            if (await _context.SubCategories.AnyAsync(asNoTrackingGetSubCategoryByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // Deleted SubCategory NameAR Should Be Does Not Exist
            ISpecification<SubCategory> asNoTrackingGetDeletedSubCategoryByNameARSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetDeletedSubCategoryByNameARSpecification), request.dto.NameAR);
            if (await _context.SubCategories.AnyAsync(asNoTrackingGetDeletedSubCategoryByNameARSpec, cancellationToken))
                return ResponseResult.Conflict<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // Deleted SubCategory NameEN Should Be Does Not Exist
            ISpecification<SubCategory> asNoTrackingGetDeletedSubCategoryByNameENSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetDeletedSubCategoryByNameENSpecification), request.dto.NameEN);
            if (await _context.SubCategories.AnyAsync(asNoTrackingGetDeletedSubCategoryByNameENSpec, cancellationToken))
                return ResponseResult.Conflict<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // Deleted SubCategory NameDE Should Be Does Not Exist
            ISpecification<SubCategory> asNoTrackingGetDeletedSubCategoryByNameDESpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetDeletedSubCategoryByNameDESpecification), request.dto.NameDE);
            if (await _context.SubCategories.AnyAsync(asNoTrackingGetDeletedSubCategoryByNameDESpec, cancellationToken))
                return ResponseResult.Conflict<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            SubCategory subCategory = _mapper.Map<SubCategory>(request.dto);
            await _context.SubCategories.CreateAsync(subCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetSubCategoryDto subCategoryDto = _mapper.Map<GetSubCategoryDto>(subCategory);
            return ResponseResult.Created(subCategoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Update SubCategory
    public async Task<ResponseModel<GetSubCategoryDto>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // SubCategory Should Be Is Exist
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByIdSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByIdSpecification), request.dto.SubCategoryId);
            if (!await _context.SubCategories.AnyAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            // Category Should Be Is Exist
            ISpecification<Category> asNoTrackingGetCategoryByIdSpec = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.dto.CategoryId);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpec, cancellationToken))
                return ResponseResult.BadRequest<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // UnDeleted SubCategory NameAR Should Not Be Duplicated
            ISpecification<SubCategory> asNoTrackingCheckDuplicatedCategoryByNameARSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedSubCategoryByNameARSpecification), request.dto.SubCategoryId, request.dto.NameAR);
            if (await _context.SubCategories.AnyAsync(asNoTrackingCheckDuplicatedCategoryByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // UnDeleted SubCategory NameEN Should Not Be Duplicated
            ISpecification<SubCategory> asNoTrackingCheckDuplicatedCategoryByNameENSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedSubCategoryByNameENSpecification), request.dto.SubCategoryId, request.dto.NameEN);
            if (await _context.SubCategories.AnyAsync(asNoTrackingCheckDuplicatedCategoryByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // UnDeleted SubCategory NameDE Should Not Be Duplicated
            ISpecification<SubCategory> asNoTrackingCheckDuplicatedCategoryByNameDESpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedSubCategoryByNameDESpecification), request.dto.SubCategoryId, request.dto.NameDE);
            if (await _context.SubCategories.AnyAsync(asNoTrackingCheckDuplicatedCategoryByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // Deleted SubCategory NameAR Should Not Be Duplicated
            ISpecification<SubCategory> asNoTrackingCheckDuplicatedDeletedSubCategoryByNameARSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameARSpecification), request.dto.SubCategoryId, request.dto.NameAR);
            if (await _context.SubCategories.AnyAsync(asNoTrackingCheckDuplicatedDeletedSubCategoryByNameARSpec, cancellationToken))
                return ResponseResult.Conflict<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // Deleted SubCategory NameEN Should Not Be Duplicated
            ISpecification<SubCategory> asNoTrackingCheckDuplicatedDeletedSubCategoryByNameENSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameENSpecification), request.dto.SubCategoryId, request.dto.NameEN);
            if (await _context.SubCategories.AnyAsync(asNoTrackingCheckDuplicatedDeletedSubCategoryByNameENSpec, cancellationToken))
                return ResponseResult.Conflict<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // Deleted SubCategory NameDE Should Not Be Duplicated
            ISpecification<SubCategory> asNoTrackingCheckDuplicatedDeletedSubCategoryByNameDESpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameDESpecification), request.dto.SubCategoryId, request.dto.NameDE);
            if (await _context.SubCategories.AnyAsync(asNoTrackingCheckDuplicatedDeletedSubCategoryByNameDESpec, cancellationToken))
                return ResponseResult.Conflict<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            ISpecification<SubCategory> asTrackingGetSubCategoryByIdSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsTrackingGetSubCategoryByIdSpecification), request.dto.SubCategoryId);
            SubCategory subCategory = await _context.SubCategories.RetrieveAsync(asTrackingGetSubCategoryByIdSpec, cancellationToken);
            subCategory.NameAR = request.dto.NameAR;
            subCategory.NameEN = request.dto.NameEN;
            subCategory.NameDE = request.dto.NameDE;
            subCategory.CategoryId = request.dto.CategoryId;
            await _context.SaveChangesAsync(cancellationToken);
            GetSubCategoryDto subCategoryDto = _mapper.Map<GetSubCategoryDto>(subCategory);
            return ResponseResult.Success(subCategoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete SubCategory
    public async Task<ResponseModel<GetSubCategoryDto>> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetSubCategoryByIdSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByIdSpecification), request.subCategoryId);
            if (!await _context.SubCategories.AnyAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            SubCategory subCategory = await _context.SubCategories.RetrieveAsync(asNoTrackingGetSubCategoryByIdSpec, cancellationToken);
            await _context.SubCategories.DeleteAsync(subCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetSubCategoryDto subCategoryDto = _mapper.Map<GetSubCategoryDto>(subCategory);
            return ResponseResult.Success(subCategoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Undo Delete
    public async Task<ResponseModel<GetSubCategoryDto>> Handle(UndoDeleteSubCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<SubCategory> asNoTrackingGetDeletedSubCategoryByIdSpec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetDeletedSubCategoryByIdSpecification), request.subCategoryId);
            if (!await _context.SubCategories.AnyAsync(asNoTrackingGetDeletedSubCategoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<SubCategory> asTrackingGetDeletedSubCategoryById_Trips_Spec = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsTrackingGetDeletedSubCategoryById_Trips_Specification), request.subCategoryId);
            SubCategory subCategory = await _context.SubCategories.RetrieveAsync(asTrackingGetDeletedSubCategoryById_Trips_Spec, cancellationToken);

            _context.UndoDeleted(ref subCategory);
            subCategory.Trips.ForEach(trip =>
            {
                _context.UndoDeleted(ref trip);
            });
            await _context.SaveChangesAsync(cancellationToken);
            GetSubCategoryDto subCategoryDto = _mapper.Map<GetSubCategoryDto>(subCategory);
            return ResponseResult.Success(subCategoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetSubCategoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
