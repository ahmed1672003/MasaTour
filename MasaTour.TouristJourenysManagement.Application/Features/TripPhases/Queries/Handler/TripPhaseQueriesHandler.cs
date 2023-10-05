using MasaTour.TouristTripsManagement.Infrastructure.Specifications.TripPhases;

namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Queries.Handler;
public class TripPhaseQueriesHandler :
    IRequestHandler<GetAllTripPhasesByTripIdQuery, ResponseModel<IEnumerable<GetTripPhaseDto>>>
{
    #region Fileds
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TripPhaseQueriesHandler(
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

    #region Get All TripPhases By TripsId
    public async Task<ResponseModel<IEnumerable<GetTripPhaseDto>>> Handle(GetAllTripPhasesByTripIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TripPhase> asNoTrackingGetAllTripPhasesByTripIdSpec = _specificationsFactory.CreateTripPhaseSpecifications(typeof(AsNoTrackingGetAllTripPhasesByTripIdSpecification), request.TripId);

            if (!await _context.TripPhases.AnyAsync(asNoTrackingGetAllTripPhasesByTripIdSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetTripPhaseDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetTripPhaseDto> tripPhaseDtos = _mapper.Map<IEnumerable<GetTripPhaseDto>>(await _context.TripPhases.RetrieveAllAsync(asNoTrackingGetAllTripPhasesByTripIdSpec, cancellationToken));
            return ResponseResult.Success(tripPhaseDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTripPhaseDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
