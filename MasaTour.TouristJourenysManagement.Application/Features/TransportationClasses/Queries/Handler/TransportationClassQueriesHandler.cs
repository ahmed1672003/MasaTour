using MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;

namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Queries.Handler;
public sealed class TransportationClassQueriesHandler :
    IRequestHandler<GetTransportationClassByIdQuery, ResponseModel<GetTransportationClassDto>>,
    IRequestHandler<GetAllTransportationClassesQuery, ResponseModel<IEnumerable<GetTransportationClassDto>>>,
    IRequestHandler<GetAllDeletedTransportationClassesQuery, ResponseModel<IEnumerable<GetTransportationClassDto>>>,
    IRequestHandler<GetAllUnDeletedTransportationClassesQuery, ResponseModel<IEnumerable<GetTransportationClassDto>>>,
    IRequestHandler<PginateDeletedTransportationClassesQuery, PaginationResponseModel<IEnumerable<GetTransportationClassDto>>>,
    IRequestHandler<PginateUnDeletedTransportationClassesQuery, PaginationResponseModel<IEnumerable<GetTransportationClassDto>>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TransportationClassQueriesHandler(
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

    #region Get Transportation Class By Id
    public async Task<ResponseModel<GetTransportationClassDto>> Handle(GetTransportationClassByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TransportationClass> asNoTrackingGetTransportationByIdSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingGetTransportationByIdSpecification),
                        request.ClassId);

            if (!await _context.TransporationClasses.AnyAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            GetTransportationClassDto Dto = _mapper.Map<GetTransportationClassDto>(await _context.TransporationClasses.RetrieveAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken));
            return ResponseResult.Success(Dto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationClassDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }

    #endregion

    #region Get All Transportation Classes 
    public async Task<ResponseModel<IEnumerable<GetTransportationClassDto>>> Handle(GetAllTransportationClassesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TransportationClass> asNoTrackingGetAllTranspotationClassesSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingGetAllTranspotationClassesSpecification));

            IEnumerable<GetTransportationClassDto> Dtos = _mapper.Map<IEnumerable<GetTransportationClassDto>>(await _context.TransporationClasses.RetrieveAllAsync(asNoTrackingGetAllTranspotationClassesSpec, cancellationToken));
            return ResponseResult.Success(Dtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTransportationClassDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Deleted Transportation Classes
    public async Task<ResponseModel<IEnumerable<GetTransportationClassDto>>> Handle(GetAllDeletedTransportationClassesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TransportationClass> asNoTrackingGetAllDeletedTranspotationClassesSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingGetAllDeletedTranspotationClassesSpecification));

            IEnumerable<GetTransportationClassDto> Dtos = _mapper.Map<IEnumerable<GetTransportationClassDto>>(await _context.TransporationClasses.RetrieveAllAsync(asNoTrackingGetAllDeletedTranspotationClassesSpec, cancellationToken));
            return ResponseResult.Success(Dtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTransportationClassDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }

    #endregion

    #region Get All Un Deleted Transportation Classes
    public async Task<ResponseModel<IEnumerable<GetTransportationClassDto>>> Handle(GetAllUnDeletedTransportationClassesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            IEnumerable<GetTransportationClassDto> Dtos = _mapper.Map<IEnumerable<GetTransportationClassDto>>(await _context.TransporationClasses.RetrieveAllAsync(cancellationToken: cancellationToken));
            return ResponseResult.Success(Dtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTransportationClassDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }

    #endregion

    #region Pginate Deleted Transportation Classes
    public async Task<PaginationResponseModel<IEnumerable<GetTransportationClassDto>>> Handle(PginateDeletedTransportationClassesQuery request, CancellationToken cancellationToken)
    {
        try
        {

            Expression<Func<TransportationClass, object>> orderBy = transportationClass => new();

            switch (request.OrderBy)
            {
                case TransportationClassOrderBy.Id:
                    orderBy = transportationClass => transportationClass.Id;
                    break;

                case TransportationClassOrderBy.NameAr:
                    orderBy = transportationClass => transportationClass.NameAR;
                    break;

                case TransportationClassOrderBy.NameEn:
                    orderBy = transportationClass => transportationClass.NameEN;
                    break;
                case TransportationClassOrderBy.NameDe:
                    orderBy = transportationClass => transportationClass.NameDE;
                    break;
                case TransportationClassOrderBy.PriceEGPPerKilometer:
                    orderBy = transportationClass => transportationClass.PriceEGPPerKilometer;
                    break;

                case TransportationClassOrderBy.PriceEURPerKilometer:
                    orderBy = transportationClass => transportationClass.PriceEURPerKilometer;
                    break;

                case TransportationClassOrderBy.PriceUSDPerKilometer:
                    orderBy = transportationClass => transportationClass.PriceUSDPerKilometer;
                    break;

                case TransportationClassOrderBy.PriceGbpPerKilometer:
                    orderBy = transportationClass => transportationClass.PriceGbpPerKilometer;
                    break;
                default:
                    orderBy = transportationClass => transportationClass.CreatedAt;
                    break;
            }

            ISpecification<TransportationClass> asNoTrackingPaginateDeletedTransportationClassesSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingPaginateDeletedTransportationClassesSpecification),
                    request.PageNumber, request.PageSize, request.KeyWords, orderBy);

            IEnumerable<GetTransportationClassDto> Dtos = _mapper.Map<IEnumerable<GetTransportationClassDto>>(
                await _context.TransporationClasses.RetrieveAllAsync(asNoTrackingPaginateDeletedTransportationClassesSpec, cancellationToken));

            ISpecification<TransportationClass> asNoTrackingGetAllDeletedTranspotationClassesSpec =
                _specificationsFactory.CreateTransporationClassesSpecifications(
                    typeof(AsNoTrackingGetAllDeletedTranspotationClassesSpecification));

            return PaginationResponseResult.Success(Dtos,
                                                    currentPage: request.PageNumber.Value,
                                                    pageSize: request.PageSize.Value,
                                                    count: await _context.TransporationClasses.CountAsync(asNoTrackingGetAllDeletedTranspotationClassesSpec, cancellationToken),
                                                    message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetTransportationClassDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Pginate Un Deleted Transportation Classes
    public async Task<PaginationResponseModel<IEnumerable<GetTransportationClassDto>>> Handle(PginateUnDeletedTransportationClassesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<TransportationClass, object>> orderBy = transportationClass => new();

            switch (request.OrderBy)
            {
                case TransportationClassOrderBy.Id:
                    orderBy = transportationClass => transportationClass.Id;
                    break;

                case TransportationClassOrderBy.NameAr:
                    orderBy = transportationClass => transportationClass.NameAR;
                    break;

                case TransportationClassOrderBy.NameEn:
                    orderBy = transportationClass => transportationClass.NameEN;
                    break;
                case TransportationClassOrderBy.NameDe:
                    orderBy = transportationClass => transportationClass.NameDE;
                    break;
                case TransportationClassOrderBy.PriceEGPPerKilometer:
                    orderBy = transportationClass => transportationClass.PriceEGPPerKilometer;
                    break;

                case TransportationClassOrderBy.PriceEURPerKilometer:
                    orderBy = transportationClass => transportationClass.PriceEURPerKilometer;
                    break;

                case TransportationClassOrderBy.PriceUSDPerKilometer:
                    orderBy = transportationClass => transportationClass.PriceUSDPerKilometer;
                    break;

                case TransportationClassOrderBy.PriceGbpPerKilometer:
                    orderBy = transportationClass => transportationClass.PriceGbpPerKilometer;
                    break;
                default:
                    orderBy = transportationClass => transportationClass.CreatedAt;
                    break;
            }

            ISpecification<TransportationClass> asNoTrackingPaginateUnDeletedTransportationClassesSpec =
                  _specificationsFactory.CreateTransporationClassesSpecifications(
                      typeof(AsNoTrackingPaginateUnDeletedTransportationClassesSpecification),
                          request.PageNumber, request.PageSize, request.KeyWords, orderBy);


            IEnumerable<GetTransportationClassDto> Dtos = _mapper.Map<IEnumerable<GetTransportationClassDto>>(
                await _context.TransporationClasses.RetrieveAllAsync(asNoTrackingPaginateUnDeletedTransportationClassesSpec, cancellationToken));

            return PaginationResponseResult.Success(Dtos,
                                                  currentPage: request.PageNumber.Value,
                                                  pageSize: request.PageSize.Value,
                                                  count: await _context.TransporationClasses.CountAsync(cancellationToken: cancellationToken),
                                                  message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetTransportationClassDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
