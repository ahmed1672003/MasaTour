using MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Commands.Handler;
public sealed class TransportationClassCommandsHandler :
    IRequestHandler<AddTransportationClassCommand, ResponseModel<GetTransportationClassDto>>,
    IRequestHandler<UpdateTransportationClassCommand, ResponseModel<GetTransportationClassDto>>,
    IRequestHandler<DeleteTransportationClassByIdCommand, ResponseModel<GetTransportationClassDto>>,
    IRequestHandler<UndoDeleteTransportationClassByIdCommand, ResponseModel<GetTransportationClassDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TransportationClassCommandsHandler(
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

    #region Add TransportationClass
    public async Task<ResponseModel<GetTransportationClassDto>> Handle(AddTransportationClassCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TransportationClass> asNoTrackingGetTransportationClassByNameARSpec = _specificationsFactory.CreateTransporationClassesSpecifications(typeof(AsNoTrackingGetTransportationClassByNameARSpecification), request.Dto.NameAR);
            if (await _context.TransporationClasses.AnyAsync(asNoTrackingGetTransportationClassByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<TransportationClass> asNoTrackingGetTransportationClassByNameENSpec = _specificationsFactory.CreateTransporationClassesSpecifications(typeof(AsNoTrackingGetTransportationClassByNameENSpecification), request.Dto.NameEN);
            if (await _context.TransporationClasses.AnyAsync(asNoTrackingGetTransportationClassByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<TransportationClass> asNoTrackingGetTransportationClassByNameDESpec = _specificationsFactory.CreateTransporationClassesSpecifications(typeof(AsNoTrackingGetTransportationClassByNameDESpecification), request.Dto.NameDE);
            if (await _context.TransporationClasses.AnyAsync(asNoTrackingGetTransportationClassByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<TransportationClass> asNoTrackingGetDeletedTransportationClassByNameARSpec = _specificationsFactory.CreateTransporationClassesSpecifications(typeof(AsNoTrackingGetDeletedTransportationClassByNameARSpecification), request.Dto.NameAR);
            if (await _context.TransporationClasses.AnyAsync(asNoTrackingGetDeletedTransportationClassByNameARSpec, cancellationToken))
                return ResponseResult.Conflict<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            ISpecification<TransportationClass> asNoTrackingGetDeletedTransportationClassByNameENSpec = _specificationsFactory.CreateTransporationClassesSpecifications(typeof(AsNoTrackingGetDeletedTransportationClassByNameENSpecification), request.Dto.NameEN);
            if (await _context.TransporationClasses.AnyAsync(asNoTrackingGetDeletedTransportationClassByNameENSpec, cancellationToken))
                return ResponseResult.Conflict<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            ISpecification<TransportationClass> asNoTrackingGetDeletedTransportationClassByNameDESpec = _specificationsFactory.CreateTransporationClassesSpecifications(typeof(AsNoTrackingGetDeletedTransportationClassByNameDESpecification), request.Dto.NameDE);
            if (await _context.TransporationClasses.AnyAsync(asNoTrackingGetDeletedTransportationClassByNameDESpec, cancellationToken))
                return ResponseResult.Conflict<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);


            TransportationClass transporationClass = _mapper.Map<TransportationClass>(request.Dto);

            await _context.TransporationClasses.CreateAsync(transporationClass, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetTransportationClassDto transportationClassDto = _mapper.Map<GetTransportationClassDto>(transporationClass);
            return ResponseResult.Created(transportationClassDto, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Update TransportationClass
    public async Task<ResponseModel<GetTransportationClassDto>> Handle(UpdateTransportationClassCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TransportationClass> asNoTrackingGetTransportationByIdSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingGetTransportationByIdSpecification),
                        request.Dto.TransportationClassId);

            if (!await _context.TransporationClasses.AnyAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<TransportationClass> asNoTrackingCheckDuplicatedTransportationClassByNameARSpec =
                _specificationsFactory
                .CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingCheckDuplicatedTransportationClassByNameARSpecification),
                        request.Dto.TransportationClassId, request.Dto.NameAR);

            if (await _context.TransporationClasses.AnyAsync(asNoTrackingCheckDuplicatedTransportationClassByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<TransportationClass> asNoTrackingCheckDuplicatedTransportationClassByNameENSpec =
                _specificationsFactory
                .CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingCheckDuplicatedTransportationClassByNameENSpecification),
                        request.Dto.TransportationClassId, request.Dto.NameEN);

            if (await _context.TransporationClasses.AnyAsync(asNoTrackingCheckDuplicatedTransportationClassByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<TransportationClass> asNoTrackingCheckDuplicatedTransportationClassByNameDESpec =
                _specificationsFactory
                .CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingCheckDuplicatedTransportationClassByNameDESpecification),
                        request.Dto.TransportationClassId, request.Dto.NameDE);

            if (await _context.TransporationClasses.AnyAsync(asNoTrackingCheckDuplicatedTransportationClassByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<TransportationClass> asNoTrackingCheckDuplicatedDeletedTransportationClassByNameARSpec =
                _specificationsFactory.
                CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameARSpecification),
                        request.Dto.TransportationClassId, request.Dto.NameAR);

            if (await _context.TransporationClasses.AnyAsync(asNoTrackingCheckDuplicatedDeletedTransportationClassByNameARSpec, cancellationToken))
                return ResponseResult.Conflict<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);



            ISpecification<TransportationClass> asNoTrackingCheckDuplicatedDeletedTransportationClassByNameENSpec =
            _specificationsFactory.
                CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameENSpecification),
                        request.Dto.TransportationClassId, request.Dto.NameEN);


            if (await _context.TransporationClasses.AnyAsync(asNoTrackingCheckDuplicatedDeletedTransportationClassByNameENSpec, cancellationToken))
                return ResponseResult.Conflict<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            ISpecification<TransportationClass> asNoTrackingCheckDuplicatedDeletedTransportationClassByNameDESpec =
               _specificationsFactory.
                   CreateTransporationClassesSpecifications(
                       typeof(AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameDESpecification),
                           request.Dto.TransportationClassId, request.Dto.NameDE);


            if (await _context.TransporationClasses.AnyAsync(asNoTrackingCheckDuplicatedDeletedTransportationClassByNameDESpec, cancellationToken))
                return ResponseResult.Conflict<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);


            ISpecification<TransportationClass> asTrackingGetTransportationClassByIdSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(
                    typeof(AsTrackingGetTransportationClassByIdSpecification),
                        request.Dto.TransportationClassId);

            TransportationClass transporationClass = await _context.TransporationClasses.RetrieveAsync(asTrackingGetTransportationClassByIdSpec, cancellationToken);

            transporationClass.NameAR = request.Dto.NameAR;
            transporationClass.NameEN = request.Dto.NameEN;
            transporationClass.NameDE = request.Dto.NameDE;
            transporationClass.DescriptionAR = request.Dto.DescriptionAR;
            transporationClass.DescriptionEN = request.Dto.DescriptionEN;
            transporationClass.DescriptionDE = request.Dto.DescriptionDE;
            transporationClass.PriceEGPPerKilometer = request.Dto.PriceEGPPerKilometer;
            transporationClass.PriceEURPerKilometer = request.Dto.PriceEURPerKilometer;
            transporationClass.PriceUSDPerKilometer = request.Dto.PriceUSDPerKilometer;
            transporationClass.PriceGbpPerKilometer = request.Dto.PriceGbpPerKilometer;

            //  await _context.TransporationClasses.UpdateAsync(transporationClass, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetTransportationClassDto transportationClassDto = _mapper.Map<GetTransportationClassDto>(transporationClass);
            return ResponseResult.Success(transportationClassDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete TransportationClass By Id
    public async Task<ResponseModel<GetTransportationClassDto>> Handle(DeleteTransportationClassByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TransportationClass> asNoTrackingGetTransportationByIdSpec =
                    _specificationsFactory.CreateTransporationClassesSpecifications(
                        typeof(AsNoTrackingGetTransportationByIdSpecification),
                            request.ClassId);

            if (!await _context.TransporationClasses.AnyAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            TransportationClass transporationClass = await _context.TransporationClasses.RetrieveAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken);
            await _context.TransporationClasses.DeleteAsync(transporationClass, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetTransportationClassDto transportationClassDto = _mapper.Map<GetTransportationClassDto>(transporationClass);
            return ResponseResult.Success(transportationClassDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Undo Delete TransportationClass By Id
    public async Task<ResponseModel<GetTransportationClassDto>> Handle(UndoDeleteTransportationClassByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TransportationClass> asNoTrackingGetDeletedTransportationClassByIdSpec =
                    _specificationsFactory.CreateTransporationClassesSpecifications(
                        typeof(AsNoTrackingGetDeletedTransportationClassByIdSpecification),
                            request.ClassId);

            if (!await _context.TransporationClasses.AnyAsync(asNoTrackingGetDeletedTransportationClassByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);



            ISpecification<TransportationClass> asTrackingGetDeletedTransportationClassByIdSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(typeof(AsTrackingGetDeletedTransportationClassByIdSpecification),
                    request.ClassId);
            TransportationClass transporationClass = await _context.TransporationClasses.RetrieveAsync(asTrackingGetDeletedTransportationClassByIdSpec, cancellationToken);

            _context.UndoDeleted(ref transporationClass);
            //  await _context.TransporationClasses.UpdateAsync(transporationClass, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetTransportationClassDto transportationClassDto = _mapper.Map<GetTransportationClassDto>(transporationClass);
            return ResponseResult.Success(transportationClassDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);

        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
