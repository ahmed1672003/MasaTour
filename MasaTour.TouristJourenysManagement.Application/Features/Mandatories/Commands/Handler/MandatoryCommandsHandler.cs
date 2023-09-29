using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;

namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Commands.Handler;
public sealed class MandatoryCommandsHandler :
    IRequestHandler<AddMandatoryCommand, ResponseModel<GetMandatoryDto>>,
    IRequestHandler<UpdateMandatoryCommand, ResponseModel<GetMandatoryDto>>,
    IRequestHandler<DeleteMandatoryByIdCommand, ResponseModel<GetMandatoryDto>>,
    IRequestHandler<UndoDeleteMandatoryByIdCommand, ResponseModel<GetMandatoryDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public MandatoryCommandsHandler(
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

    #region Add Mandatory
    public async Task<ResponseModel<GetMandatoryDto>> Handle(AddMandatoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Undeleted nameAr Should Be Is Not Exist
            ISpecification<Mandatory> asNoTrackingGetMandatoryByNameARSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingGetMandatoryByNameARSpecification), request.dto.NameAR);


            if (await _context.Mandatories.AnyAsync(asNoTrackingGetMandatoryByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // Undeleted nameEn Should Be Is Not Exist
            ISpecification<Mandatory> asNoTrackingGetMandatoryByNameENSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingGetMandatoryByNameENSpecification), request.dto.NameEN);


            if (await _context.Mandatories.AnyAsync(asNoTrackingGetMandatoryByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // Undeleted nameDe Should Be Is Not Exist
            ISpecification<Mandatory> asNoTrackingGetMandatoryByNameDESpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingGetMandatoryByNameDESpecification), request.dto.NameDE);


            if (await _context.Mandatories.AnyAsync(asNoTrackingGetMandatoryByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // Deleted nameAr Should Be Is Not Exist 
            ISpecification<Mandatory> asNoTrackingGetDeletedMandatoryByNameARSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingGetDeletedMandatoryByNameARSpecification), request.dto.NameAR);


            if (await _context.Mandatories.AnyAsync(asNoTrackingGetDeletedMandatoryByNameARSpec, cancellationToken))
                return ResponseResult.Conflict<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // Deleted nameEn Should Be Is Not Exist
            ISpecification<Mandatory> asNoTrackingGetDeletedMandatoryByNameENSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingGetDeletedMandatoryByNameENSpecification), request.dto.NameEN);


            if (await _context.Mandatories.AnyAsync(asNoTrackingGetDeletedMandatoryByNameENSpec, cancellationToken))
                return ResponseResult.Conflict<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            // Deleted nameDe Should Be Is Not Exist
            ISpecification<Mandatory> asNoTrackingGetDeletedMandatoryByNameDESpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingGetDeletedMandatoryByNameDESpecification), request.dto.NameDE);


            if (await _context.Mandatories.AnyAsync(asNoTrackingGetDeletedMandatoryByNameDESpec, cancellationToken))
                return ResponseResult.Conflict<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            Mandatory mandatory = _mapper.Map<Mandatory>(request.dto);
            await _context.Mandatories.CreateAsync(mandatory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetMandatoryDto mandatoryDto = _mapper.Map<GetMandatoryDto>(mandatory);
            return ResponseResult.Created(mandatoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {

            return ResponseResult.InternalServerError<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Update Mandatory
    public async Task<ResponseModel<GetMandatoryDto>> Handle(UpdateMandatoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Undeleted Mandatory Should Be Is Exist
            ISpecification<Mandatory> asNoTrackingetGetMandatoryByIdSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingetGetMandatoryByIdSpecification),
                                                request.dto.MandatoryId);

            if (!await _context.Mandatories.AnyAsync(asNoTrackingetGetMandatoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);


            // Undeleted NameAr Should Be Is Not Duplicated
            ISpecification<Mandatory> asNoTrackingCheckDuplicatedMandatoryByNameARSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingCheckDuplicatedMandatoryByNameARSpecification),
                                                request.dto.MandatoryId, request.dto.NameAR);

            if (await _context.Mandatories.AnyAsync(asNoTrackingCheckDuplicatedMandatoryByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            // Undeleted NameEn Should Be Is Not Duplicated
            ISpecification<Mandatory> asNoTrackingCheckDuplicatedMandatoryByNameENSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingCheckDuplicatedMandatoryByNameENSpecification),
                                                request.dto.MandatoryId, request.dto.NameEN);

            if (await _context.Mandatories.AnyAsync(asNoTrackingCheckDuplicatedMandatoryByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            // Undeleted NameDe Should Be Is Not Duplicated
            ISpecification<Mandatory> asNoTrackingCheckDuplicatedMandatoryByNameDESpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingCheckDuplicatedMandatoryByNameDESpecification),
                                                request.dto.MandatoryId, request.dto.NameDE);

            if (await _context.Mandatories.AnyAsync(asNoTrackingCheckDuplicatedMandatoryByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            // Deleted NameAr Should Be Is Not Duplicated
            ISpecification<Mandatory> asNoTrackingCheckDuplicatedDeletedMandatoryByNameARSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedMandatoryByNameARSpecification),
                                                request.dto.MandatoryId, request.dto.NameAR);

            if (await _context.Mandatories.AnyAsync(asNoTrackingCheckDuplicatedDeletedMandatoryByNameARSpec, cancellationToken))
                return ResponseResult.Conflict<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);


            // Deleted NameEn Should Be Is Not Duplicated
            ISpecification<Mandatory> asNoTrackingCheckDuplicatedDeletedMandatoryByNameENSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedMandatoryByNameENSpecification),
                                                request.dto.MandatoryId, request.dto.NameEN);

            if (await _context.Mandatories.AnyAsync(asNoTrackingCheckDuplicatedDeletedMandatoryByNameENSpec, cancellationToken))
                return ResponseResult.Conflict<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);


            // Deleted NameDe Should Be Is Not Duplicated
            ISpecification<Mandatory> asNoTrackingCheckDuplicatedDeletedMandatoryByNameDESpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingCheckDuplicatedDeletedMandatoryByNameDESpecification),
                                                request.dto.MandatoryId, request.dto.NameDE);

            if (await _context.Mandatories.AnyAsync(asNoTrackingCheckDuplicatedDeletedMandatoryByNameDESpec, cancellationToken))
                return ResponseResult.Conflict<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);


            ISpecification<Mandatory> asTrackingGetMandatoryByIdSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsTrackingGetMandatoryByIdSpecification),
                                                request.dto.MandatoryId);

            Mandatory mandatory = await _context.Mandatories.RetrieveAsync(asTrackingGetMandatoryByIdSpec, cancellationToken);
            mandatory.NameAR = request.dto.NameAR;
            mandatory.NameEN = request.dto.NameEN;
            mandatory.NameDE = request.dto.NameDE;
            mandatory.DesceiptionAR = request.dto.DesceiptionAR;
            mandatory.DesceiptionEN = request.dto.DesceiptionEN;
            mandatory.DesceiptionDE = request.dto.DesceiptionDE;
            await _context.SaveChangesAsync(cancellationToken);
            GetMandatoryDto mandatoryDto = _mapper.Map<GetMandatoryDto>(mandatory);
            return ResponseResult.Success(mandatoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete Mandatory
    public async Task<ResponseModel<GetMandatoryDto>> Handle(DeleteMandatoryByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Undeleted Mandatory Should Be Is Exist
            ISpecification<Mandatory> asNoTrackingetGetMandatoryByIdSpec = _specificationsFactory.
                                        CreateMandatorySpecifications(typeof(AsNoTrackingetGetMandatoryByIdSpecification), request.Id);

            if (!await _context.Mandatories.AnyAsync(asNoTrackingetGetMandatoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            Mandatory mandatory = await _context.Mandatories.RetrieveAsync(asNoTrackingetGetMandatoryByIdSpec, cancellationToken);
            await _context.Mandatories.DeleteAsync(mandatory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetMandatoryDto mandatoryDto = _mapper.Map<GetMandatoryDto>(mandatory);
            return ResponseResult.Success(mandatoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {

            return ResponseResult.InternalServerError<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Undo Delete
    public async Task<ResponseModel<GetMandatoryDto>> Handle(UndoDeleteMandatoryByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Mandatory> asNoTrackingGetDeletedMandatoryByIdSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingGetDeletedMandatoryByIdSpecification), request.Id);

            if (!await _context.Mandatories.AnyAsync(asNoTrackingGetDeletedMandatoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Mandatory> asTrackingGetDeletedMandatoryById_TripMandatoryMapper_Spec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsTrackingGetDeletedMandatoryById_TripMandatoryMapper_Specification), request.Id);

            Mandatory mandatory = await _context.Mandatories.RetrieveAsync(asTrackingGetDeletedMandatoryById_TripMandatoryMapper_Spec, cancellationToken);
            _context.UndoDeleted(ref mandatory);
            await _context.SaveChangesAsync(cancellationToken);
            GetMandatoryDto mandatoryDto = _mapper.Map<GetMandatoryDto>(mandatory);
            return ResponseResult.Success(mandatoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
