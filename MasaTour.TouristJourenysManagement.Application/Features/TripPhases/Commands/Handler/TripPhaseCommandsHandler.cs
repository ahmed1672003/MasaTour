using MasaTour.TouristTripsManagement.Infrastructure.Specifications.TripPhases;

namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Commands.Handler;
public sealed class TripPhaseCommandsHandler :
    IRequestHandler<UpdateTripPhaseCommand, ResponseModel<GetTripPhaseDto>>,
    IRequestHandler<DeleteTripPhaseByPhaseIdCommand, ResponseModel<GetTripPhaseDto>>,
    IRequestHandler<DeleteTripPhasesByTripIdCommand, ResponseModel<GetTripPhaseDto>>
{
    #region Fileds
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TripPhaseCommandsHandler(
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

    #region Update TripPhase 
    public async Task<ResponseModel<GetTripPhaseDto>> Handle(UpdateTripPhaseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TripPhase> asNoTrackingGetTripPhaseByIdSpec = _specificationsFactory.
                        CreateTripPhaseSpecifications(typeof(AsNoTrackingGetTripPhaseByIdSpecification), request.Dto.TripPhaseId);

            if (!await _context.TripPhases.AnyAsync(asNoTrackingGetTripPhaseByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripPhaseDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<TripPhase> asTrackingGetTripPhaseSpec = _specificationsFactory.CreateTripPhaseSpecifications(typeof(AsTrackingGetTripPhaseSpecification), request.Dto.TripPhaseId);
            TripPhase tripPhase = await _context.TripPhases.RetrieveAsync(asTrackingGetTripPhaseSpec, cancellationToken);
            tripPhase.PhaseNumber = request.Dto.PhaseNumber;
            tripPhase.ToHours = request.Dto.ToHours;
            tripPhase.ToMinutes = request.Dto.ToMinutes;
            tripPhase.FromMinutes = request.Dto.FromMinutes;
            tripPhase.FromHours = request.Dto.FromHours;
            tripPhase.FromTimeAR = request.Dto.FromTimeAR;
            tripPhase.FromTimeDE = request.Dto.FromTimeDE;
            tripPhase.FromTimeEN = request.Dto.FromTimeEN;
            tripPhase.DescriptionAR = request.Dto.DesceiptionAR;
            tripPhase.DescriptionDE = request.Dto.DesceiptionDE;
            tripPhase.DescriptionEN = request.Dto.DesceiptionEN;
            tripPhase.LocationNameAR = request.Dto.LocationNameAR;
            tripPhase.LocationNameDE = request.Dto.LocationNameDE;
            tripPhase.LocationNameEN = request.Dto.LocationNameEN;

            await _context.TripPhases.UpdateAsync(tripPhase, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetTripPhaseDto tripPhaseDto = _mapper.Map<GetTripPhaseDto>(tripPhase);
            return ResponseResult.Success(tripPhaseDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripPhaseDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete TripPhase By PhaseId
    public async Task<ResponseModel<GetTripPhaseDto>> Handle(DeleteTripPhaseByPhaseIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TripPhase> asNoTrackingGetTripPhaseByIdSpec = _specificationsFactory.CreateTripPhaseSpecifications(typeof(AsNoTrackingGetTripPhaseByIdSpecification), request.PhaseId);
            if (!await _context.TripPhases.AnyAsync(asNoTrackingGetTripPhaseByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripPhaseDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);
            await _context.TripPhases.ExecuteDeleteAsync(asNoTrackingGetTripPhaseByIdSpec, cancellationToken);
            return ResponseResult.Success<GetTripPhaseDto>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripPhaseDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete TripPhases By TripId
    public async Task<ResponseModel<GetTripPhaseDto>> Handle(DeleteTripPhasesByTripIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TripPhase> asNoTrackingGetTripPhaseByTripIdSpec = _specificationsFactory.CreateTripPhaseSpecifications(typeof(AsNoTrackingGetTripPhaseByTripIdSpecification), request.TripId);
            if (!await _context.TripPhases.AnyAsync(asNoTrackingGetTripPhaseByTripIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripPhaseDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            await _context.TripPhases.ExecuteDeleteAsync(asNoTrackingGetTripPhaseByTripIdSpec, cancellationToken);
            return ResponseResult.Success<GetTripPhaseDto>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripPhaseDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
