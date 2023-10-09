using MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;

namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Commands.Handler;
public sealed class TransportationCommandsHandler :
    IRequestHandler<AddTransportationCommand, ResponseModel<GetTransportationDto>>,
    IRequestHandler<UpdateTransportationCommand, ResponseModel<GetTransportationDto>>,
    IRequestHandler<DeleteTransportationByIdCommand, ResponseModel<GetTransportationDto>>,
    IRequestHandler<UndoDeleteTransportationByIdCommand, ResponseModel<GetTransportationDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TransportationCommandsHandler(
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

    #region AddTransportationCommand
    public async Task<ResponseModel<GetTransportationDto>> Handle(AddTransportationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TransportationClass> asNoTrackingGetTransportationClassByIdSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingGetTransportationClassByIdSpecification),
                        request.Dto.TransportationClassId);

            if (!await _context.TransporationClasses.AnyAsync(asNoTrackingGetTransportationClassByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            Transportation transportation = _mapper.Map<Transportation>(request.Dto);
            await _context.Transporations.CreateAsync(transportation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetTransportationDto Dto = _mapper.Map<GetTransportationDto>(transportation);
            return ResponseResult.Created(Dto, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region UpdateTransportationCommand
    public async Task<ResponseModel<GetTransportationDto>> Handle(UpdateTransportationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Transportation> asNoTrackingGetTransportationByIdSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsNoTrackingGetTransportationByIdSpecification),
                            request.Dto.TransportationId);


            ISpecification<TransportationClass> asNoTrackingGetTransportationClassByIdSpec =
              _specificationsFactory.CreateTransporationClassesSpecifications(
                  typeof(AsNoTrackingGetTransportationClassByIdSpecification),
                      request.Dto.TransportationClassId);

            if (!await _context.TransporationClasses.AnyAsync(asNoTrackingGetTransportationClassByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            if (!await _context.Transporations.AnyAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);


            ISpecification<Transportation> asTrackingGetTransportationByIdSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsTrackingGetTransportationByIdSpecification),
                    request.Dto.TransportationId);

            Transportation transportation = await _context.Transporations.RetrieveAsync(asTrackingGetTransportationByIdSpec, cancellationToken);

            transportation.TransportationClassId = request.Dto.TransportationClassId;
            transportation.Model = request.Dto.Model;
            transportation.NumberOfSeats = request.Dto.NumberOfSeats;
            transportation.DescriptionEN = request.Dto.DesceiptionEN;
            transportation.DescriptionAR = request.Dto.DesceiptionAR;
            transportation.DescriptionDE = request.Dto.DesceiptionDE;
            await _context.SaveChangesAsync(cancellationToken);

            GetTransportationDto Dto = _mapper.Map<GetTransportationDto>(transportation);
            return ResponseResult.Success(Dto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region DeleteTransportationByIdCommand
    public async Task<ResponseModel<GetTransportationDto>> Handle(DeleteTransportationByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Transportation> asNoTrackingGetTransportationByIdSpec =
             _specificationsFactory.CreateTransporationsSpecifications(
                 typeof(AsNoTrackingGetTransportationByIdSpecification),
                         request.TransportationId);

            if (!await _context.Transporations.AnyAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);


            Transportation transportation = await _context.Transporations.RetrieveAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken);
            await _context.Transporations.DeleteAsync(transportation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetTransportationDto Dto = _mapper.Map<GetTransportationDto>(transportation);
            return ResponseResult.Success(Dto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region UndoDeleteTransportationByIdCommand
    public async Task<ResponseModel<GetTransportationDto>> Handle(UndoDeleteTransportationByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Transportation> asNoTrackingGetDeletedTransportationByIdSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsNoTrackingGetDeletedTransportationByIdSpecification),
                    request.TransportationId);

            if (!await _context.Transporations.AnyAsync(asNoTrackingGetDeletedTransportationByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Transportation> asTrackingGetDeletedTransportationByIdSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsTrackingGetDeletedTransportationByIdSpecification),
                        request.TransportationId);

            Transportation transportation = await _context.Transporations.RetrieveAsync(asTrackingGetDeletedTransportationByIdSpec, cancellationToken);
            _context.UndoDeleted(ref transportation);
            await _context.SaveChangesAsync(cancellationToken);
            GetTransportationDto Dto = _mapper.Map<GetTransportationDto>(transportation);
            return ResponseResult.Success(Dto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}