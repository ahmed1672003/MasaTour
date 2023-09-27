namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands.Handler;
public sealed class TripCommandsHandler :
    IRequestHandler<AddTripCommand, ResponseModel<GetTripDto>>,
    IRequestHandler<UpdateTripCommand, ResponseModel<GetTripDto>>,
    IRequestHandler<DeleteTripByIdCommand, ResponseModel<GetTripDto>>,
    IRequestHandler<UndoDeleteTripByIdCommand, ResponseModel<GetTripDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TripCommandsHandler(
    IUnitOfWork context,
    ISpecificationsFactory specificationsFactory,
    IStringLocalizer<SharedResources> stringLocalizer
,
    IMapper mapper)
    {
        _context = context;
        _specificationsFactory = specificationsFactory;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
    }
    #endregion

    #region Add Trip
    public async Task<ResponseModel<GetTripDto>> Handle(AddTripCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetTripByCodeSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingGetTripByCodeSpecification), request.dto.Code);
            if (await _context.Trips.AnyAsync(asNoTrackingGetTripByCodeSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingGetTripByNameARSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingGetTripByNameARSpecification), request.dto.NameAR);
            if (await _context.Trips.AnyAsync(asNoTrackingGetTripByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingGetTripByNameENSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingGetTripByNameENSpecification), request.dto.NameEN);
            if (await _context.Trips.AnyAsync(asNoTrackingGetTripByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingGetTripByNameDESpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingGetTripByNameDESpecification), request.dto.NameDE);
            if (await _context.Trips.AnyAsync(asNoTrackingGetTripByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check category
            ISpecification<Category> asNoTrackingGetCategoryByIdSpecification = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.dto.CategoryId);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpecification, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);



            Trip trip = _mapper.Map<Trip>(request.dto);

            await _context.Trips.CreateAsync(trip, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            return ResponseResult.Created(tripDto, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Update Trip
    public async Task<ResponseModel<GetTripDto>> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetTripByIdSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingGetTripByIdSpecification), request.dto.TripId);
            if (!await _context.Trips.AnyAsync(asNoTrackingGetTripByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);


            ISpecification<Trip> asNoTrackingCheckDuplicatedTripByCodeSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingCheckDuplicatedTripByCodeSpecification), request.dto.TripId, request.dto.Code);
            if (await _context.Trips.AnyAsync(asNoTrackingCheckDuplicatedTripByCodeSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingCheckDuplicatedTripByNameARSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingCheckDuplicatedTripByNameARSpecification), request.dto.TripId, request.dto.NameAR);
            if (await _context.Trips.AnyAsync(asNoTrackingCheckDuplicatedTripByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<Trip> asNoTrackingCheckDuplicatedTripByNameENSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingCheckDuplicatedTripByNameENSpecification), request.dto.TripId, request.dto.NameEN);
            if (await _context.Trips.AnyAsync(asNoTrackingCheckDuplicatedTripByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingCheckDuplicatedTripByNameDESpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingCheckDuplicatedTripByNameDESpecification), request.dto.TripId, request.dto.NameDE);
            if (await _context.Trips.AnyAsync(asNoTrackingCheckDuplicatedTripByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            // check category
            ISpecification<Category> asNoTrackingGetCategoryByIdSpecification = _specificationsFactory.CreatCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.dto.CategoryId);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpecification, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingGetTripByIdSpecification = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingGetTripByIdSpecification), request.dto.TripId);
            Trip trip = await _context.Trips.RetrieveAsync(asNoTrackingGetTripByIdSpecification, cancellationToken);
            trip.Code = request.dto.Code;
            trip.NameAR = request.dto.NameAR;
            trip.NameEN = request.dto.NameEN;
            trip.NameDE = request.dto.NameDE;
            trip.FromAR = request.dto.FromAR;
            trip.FromEN = request.dto.FromEN;
            trip.FromDE = request.dto.FromDE;
            trip.ToAR = request.dto.ToAR;
            trip.ToEN = request.dto.ToEN;
            trip.ToDE = request.dto.ToDE;
            trip.LongDesceiptionAR = request.dto.LongDesceiptionAR;
            trip.LongDesceiptionEN = request.dto.LongDesceiptionEN;
            trip.LongDesceiptionDE = request.dto.LongDesceiptionDE;
            trip.MiniDesceiptionAR = request.dto.MiniDesceiptionAR;
            trip.MiniDesceiptionEN = request.dto.MiniDesceiptionEN;
            trip.MiniDesceiptionDE = request.dto.MiniDesceiptionDE;
            trip.IsFamous = request.dto.IsFamous;
            trip.IsActive = request.dto.IsActive;
            trip.StartDate = request.dto.StartDate;
            trip.EndDate = request.dto.EndDate;
            trip.PriceEGP = request.dto.PriceEGP;
            trip.PriceEUR = request.dto.PriceEUR;
            trip.PriceGBP = request.dto.PriceEGP;
            trip.PriceUSD = request.dto.PriceUSD;
            trip.CategoryId = request.dto.CategoryId;

            await _context.Trips.UpdateAsync(trip, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            return ResponseResult.Success(tripDto);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete Trip
    public async Task<ResponseModel<GetTripDto>> Handle(DeleteTripByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetTripByIdSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingGetTripByIdSpecification), request.Id);
            if (!await _context.Trips.AnyAsync(asNoTrackingGetTripByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Trip> asTrackingGetTripByIdSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsTrackingGetTripByIdSpecification), request.Id);

            Trip trip = await _context.Trips.RetrieveAsync(asTrackingGetTripByIdSpec, cancellationToken);

            await _context.Trips.DeleteAsync(trip);
            await _context.SaveChangesAsync(cancellationToken);

            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            return ResponseResult.Success(tripDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Uudo Delete Trip
    public async Task<ResponseModel<GetTripDto>> Handle(UndoDeleteTripByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetDeletedTripByIdSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsNoTrackingGetDeletedTripByIdSpecification), request.Id);
            if (!await _context.Trips.AnyAsync(asNoTrackingGetDeletedTripByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Trip> asTrackingGetDeletedTripByIdSpec = _specificationsFactory.CreatTripSpecifications(typeof(AsTrackingGetDeletedTripByIdSpecification), request.Id);
            Trip trip = await _context.Trips.RetrieveAsync(asTrackingGetDeletedTripByIdSpec, cancellationToken);
            _context.Trips.UndoDeleted(ref trip);
            await _context.SaveChangesAsync();

            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            return ResponseResult.Success(tripDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
