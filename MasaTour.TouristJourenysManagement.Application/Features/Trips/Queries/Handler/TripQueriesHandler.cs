﻿namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries.Handler;
public sealed class TripQueriesHandler :
    IRequestHandler<GetAllActiveTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllDeletedTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllFamousTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllNotActiveTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllUnDeletedTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetAllUnFamousTripsQuery, ResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<PaginateUnDeletedTripsQuery, PaginationResponseModel<IEnumerable<GetTripDto>>>,
    IRequestHandler<GetTripByIdQuery, ResponseModel<GetTripDto>>
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

    #region Paginate Trips
    public async Task<PaginationResponseModel<IEnumerable<GetTripDto>>> Handle(PaginateUnDeletedTripsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Trips.AnyAsync(cancellationToken: cancellationToken))
                return PaginationResponseResult.NotFound<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

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
            return PaginationResponseResult.Success(tripDtos, pageSize: request.pageSize.Value, currentPage: request.pageNumber.Value, count: tripDtos.Count());
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetTripDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
