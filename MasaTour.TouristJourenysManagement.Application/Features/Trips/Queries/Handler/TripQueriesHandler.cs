namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries.Handler;
public sealed class TripQueriesHandler :
    IRequestHandler<GetAllActiveTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllDeletedTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllFamousTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllNotActiveTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllUnDeletedTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllUnFamousTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<PaginateUnDeletedTripsQuery, PaginationResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<PaginateDeletedTripsQuery, PaginationResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetTripByIdQuery, ResponseModel<GetTripDto>>,
    IRequestHandler<GetTripById_Mandatories_Images_Query, ResponseModel<GetTrip_Mandatories_Images_Dto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TripQueriesHandler(
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

    #region Get Trip By Id
    public async Task<ResponseModel<GetTripDto>> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetTripByIdSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByIdSpecification), request.Id);
            if (!await _context.Trips.AnyAsync(asNoTrackingGetTripByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            GetTripDto tripDto = _mapper.Map<GetTripDto>(await _context.Trips.RetrieveAsync(asNoTrackingGetTripByIdSpec, cancellationToken));
            return ResponseResult.Success(tripDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region GetTripById_Mandatories_Images
    public async Task<ResponseModel<GetTrip_Mandatories_Images_Dto>> Handle(GetTripById_Mandatories_Images_Query request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetTripByIdSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByIdSpecification), request.TripId);
            if (!await _context.Trips.AnyAsync(asNoTrackingGetTripByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTrip_Mandatories_Images_Dto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Trip> AsNoTrackingGetTripById_Mandatories_Images_Specific = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripById_Mandatories_Images_Specification), request.TripId);
            Trip trip = await _context.Trips.RetrieveAsync(AsNoTrackingGetTripById_Mandatories_Images_Specific, cancellationToken);

            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            IEnumerable<GetMandatoryDto> mandatoryDtos = new HashSet<GetMandatoryDto>();
            IEnumerable<GetImageDto> imageDtos = new HashSet<GetImageDto>();

            if (trip.TripMandatoryMappers.Any())
                mandatoryDtos = _mapper.Map<IEnumerable<GetMandatoryDto>>(trip.TripMandatoryMappers.Select(tm => tm.Mandatory));

            if (trip.TripImageMappers.Any())
                imageDtos = _mapper.Map<IEnumerable<GetImageDto>>(trip.TripImageMappers.Select(ti => ti.Image));


            GetTrip_Mandatories_Images_Dto trip_Mandatoriies_Images_Dto = new()
            {
                Trip = tripDto,
                TripMandatories = mandatoryDtos,
                TripImages = imageDtos
            };

            return ResponseResult.Success(trip_Mandatoriies_Images_Dto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTrip_Mandatories_Images_Dto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });

        }
    }
    #endregion

    #region Get All Trips
    public async Task<ResponseModel<IEnumerable<GetTripDto>>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetAllTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetAllTripsSpecification));
            if (!await _context.Trips.AnyAsync(asNoTrackingGetAllTripsSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);
            IEnumerable<GetTripDto> tripDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(asNoTrackingGetAllTripsSpec, cancellationToken));
            return ResponseResult.Success(tripDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Deleted Trips
    public async Task<ResponseModel<IEnumerable<GetTripDto>>> Handle(GetAllDeletedTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetAllDeletedTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetAllDeletedTripsSpecification));
            if (!await _context.Trips.AnyAsync(asNoTrackingGetAllDeletedTripsSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetTripDto> tripDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(asNoTrackingGetAllDeletedTripsSpec, cancellationToken));
            return ResponseResult.Success(tripDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All UnDeleted Trips
    public async Task<ResponseModel<IEnumerable<GetTripDto>>> Handle(GetAllUnDeletedTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Trips.AnyAsync(cancellationToken: cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetTripDto> tripDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(cancellationToken: cancellationToken));

            return ResponseResult.Success(tripDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Famous Trips
    public async Task<ResponseModel<IEnumerable<GetTripDto>>> Handle(GetAllFamousTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetAllFamousTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetAllFamousTripsSpecification));
            if (!await _context.Trips.AnyAsync(asNoTrackingGetAllFamousTripsSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetTripDto> tripDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(asNoTrackingGetAllFamousTripsSpec, cancellationToken));
            return ResponseResult.Success(tripDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All UnFamous Trips
    public async Task<ResponseModel<IEnumerable<GetTripDto>>> Handle(GetAllUnFamousTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetAllUnFamousTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetAllUnFamousTripsSpecification));
            if (await _context.Trips.AnyAsync(asNoTrackingGetAllUnFamousTripsSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetTripDto> tripDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(asNoTrackingGetAllUnFamousTripsSpec, cancellationToken));
            return ResponseResult.Success(tripDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Active Trips
    public async Task<ResponseModel<IEnumerable<GetTripDto>>> Handle(GetAllActiveTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetAllActiveTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetAllActiveTripsSpecification));
            if (!await _context.Trips.AnyAsync(asNoTrackingGetAllActiveTripsSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetTripDto> tripDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(asNoTrackingGetAllActiveTripsSpec, cancellationToken));
            return ResponseResult.Success(tripDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Not Active Trips
    public async Task<ResponseModel<IEnumerable<GetTripDto>>> Handle(GetAllNotActiveTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> aAsNoTrackingGetAllNotActiveTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetAllNotActiveTripsSpecification));
            if (!await _context.Trips.AnyAsync(aAsNoTrackingGetAllNotActiveTripsSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetTripDto> tripDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(aAsNoTrackingGetAllNotActiveTripsSpec, cancellationToken));
            return ResponseResult.Success(tripDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Paginate UnDeleted Trips
    public async Task<PaginationResponseModel<IEnumerable<GetTripDto>>> Handle(PaginateUnDeletedTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<Trip, object>> orderBy = category => new();
            switch (request.orderBy)
            {
                case TripOrderBy.Id:
                    orderBy = Trip => Trip.Id;
                    break;
                case TripOrderBy.StartDate:
                    orderBy = Trip => Trip.StartDate;
                    break;
                case TripOrderBy.EndDate:
                    orderBy = Trip => Trip.EndDate;
                    break;
                case TripOrderBy.NameAR:
                    orderBy = Trip => Trip.NameAR;
                    break;
                case TripOrderBy.NameEN:
                    orderBy = Trip => Trip.NameEN;
                    break;
                case TripOrderBy.NameDE:
                    orderBy = Trip => Trip.NameDE;
                    break;
                case TripOrderBy.Code:
                    orderBy = Trip => Trip.Code;
                    break;
                case TripOrderBy.PriceEUR:
                    orderBy = Trip => Trip.PriceEUR;
                    break;
                case TripOrderBy.PriceUSD:
                    orderBy = Trip => Trip.PriceUSD;
                    break;
                case TripOrderBy.PriceEGP:
                    orderBy = Trip => Trip.PriceEGP;
                    break;

                case TripOrderBy.PriceGBP:
                    orderBy = Trip => Trip.PriceGBP;
                    break;

                default:
                    orderBy = Trip => Trip.CreatedAt;
                    break;
            }
            ISpecification<Trip> asNoTrackingPaginateTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingPaginateUnDeletedTripsSpecification), request.pageNumber, request.pageSize, request.keyWords, orderBy);
            IEnumerable<GetTripDto> tripDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(asNoTrackingPaginateTripsSpec, cancellationToken));
            return PaginationResponseResult.Success(tripDtos, pageSize: request.pageSize.Value, currentPage: request.pageNumber.Value, count: await _context.Trips.CountAsync());
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Paginate Deleted Trips
    public async Task<PaginationResponseModel<IEnumerable<GetTripDto>>> Handle(PaginateDeletedTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<Trip, object>> orderBy = category => new();
            switch (request.orderBy)
            {
                case TripOrderBy.Id:
                    orderBy = Trip => Trip.Id;
                    break;
                case TripOrderBy.StartDate:
                    orderBy = Trip => Trip.StartDate;
                    break;
                case TripOrderBy.EndDate:
                    orderBy = Trip => Trip.EndDate;
                    break;
                case TripOrderBy.NameAR:
                    orderBy = Trip => Trip.NameAR;
                    break;
                case TripOrderBy.NameEN:
                    orderBy = Trip => Trip.NameEN;
                    break;
                case TripOrderBy.NameDE:
                    orderBy = Trip => Trip.NameDE;
                    break;
                case TripOrderBy.Code:
                    orderBy = Trip => Trip.Code;
                    break;
                case TripOrderBy.PriceEUR:
                    orderBy = Trip => Trip.PriceEUR;
                    break;
                case TripOrderBy.PriceUSD:
                    orderBy = Trip => Trip.PriceUSD;
                    break;
                case TripOrderBy.PriceEGP:
                    orderBy = Trip => Trip.PriceEGP;
                    break;

                case TripOrderBy.PriceGBP:
                    orderBy = Trip => Trip.PriceGBP;
                    break;

                default:
                    orderBy = Trip => Trip.CreatedAt;
                    break;
            }

            ISpecification<Trip> asNoTrackingPaginateDeletedTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingPaginateDeletedTripsSpecification), request.PageNumber, request.PageSize, request.KeyWorks, orderBy);
            IEnumerable<GetTripDto> tripsDtos = _mapper.Map<IEnumerable<GetTripDto>>(await _context.Trips.RetrieveAllAsync(asNoTrackingPaginateDeletedTripsSpec, cancellationToken));
            ISpecification<Trip> asNoTrackingGetAllDeletedTripsSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetAllDeletedTripsSpecification));
            return PaginationResponseResult.Success(tripsDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success],
                currentPage: request.PageNumber.Value, pageSize: request.PageSize.Value, count: await _context.Trips.CountAsync(asNoTrackingGetAllDeletedTripsSpec, cancellationToken));
        }
        catch (Exception ex)
        {

            return PaginationResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
