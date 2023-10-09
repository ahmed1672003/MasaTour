using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;

namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Queries.Handler;
public sealed class TransportationQueriesHandler :
    IRequestHandler<GetTransportationByIdQuery, ResponseModel<GetTransportationDto>>,
    IRequestHandler<GetAllTransportationsQuery, ResponseModel<IEnumerable<GetTransportationDto>>>,
    IRequestHandler<GetAllDeletedTransportationsQuery, ResponseModel<IEnumerable<GetTransportationDto>>>,
    IRequestHandler<GetAllUnDeletedTransportationsQuery, ResponseModel<IEnumerable<GetTransportationDto>>>,
    IRequestHandler<PaginateDeletedTransportationsQuery, PaginationResponseModel<IEnumerable<GetTransportationDto>>>,
    IRequestHandler<PaginateUnDeletedTransportationsQuery, PaginationResponseModel<IEnumerable<GetTransportationDto>>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TransportationQueriesHandler(
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

    #region GetTransportationByIdQuery
    public async Task<ResponseModel<GetTransportationDto>> Handle(GetTransportationByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Transportation> asNoTrackingGetTransportationByIdSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsNoTrackingGetTransportationByIdSpecification),
                        request.TransportationId);
            if (!await _context.Transporations.AnyAsync(asNoTrackingGetTransportationByIdSpec))
                return ResponseResult.NotFound<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            GetTransportationDto Dto = _mapper.Map<GetTransportationDto>(await _context.Transporations.RetrieveAsync(asNoTrackingGetTransportationByIdSpec, cancellationToken));
            return ResponseResult.Success(Dto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTransportationDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region GetAllTransportationsQuery
    public async Task<ResponseModel<IEnumerable<GetTransportationDto>>> Handle(GetAllTransportationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Transportation> asNoTrackingGetAllTransportationsSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsNoTrackingGetAllTransportationsSpecification));
            IEnumerable<GetTransportationDto> Dtos = _mapper.Map<IEnumerable<GetTransportationDto>>(await _context.Transporations.RetrieveAllAsync(asNoTrackingGetAllTransportationsSpec, cancellationToken));
            return ResponseResult.Success(Dtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTransportationDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region GetAllDeletedTransportationsQuery
    public async Task<ResponseModel<IEnumerable<GetTransportationDto>>> Handle(GetAllDeletedTransportationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Transportation> asNoTrackingGetAllDeletedTransportationsSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsNoTrackingGetAllDeletedTransportationsSpecification));

            IEnumerable<GetTransportationDto> Dtos = _mapper.Map<IEnumerable<GetTransportationDto>>(await _context.Transporations.RetrieveAllAsync(asNoTrackingGetAllDeletedTransportationsSpec, cancellationToken));
            return ResponseResult.Success(Dtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTransportationDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region GetAllUnDeletedTransportationsQuery
    public async Task<ResponseModel<IEnumerable<GetTransportationDto>>> Handle(GetAllUnDeletedTransportationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            IEnumerable<GetTransportationDto> Dtos = _mapper.Map<IEnumerable<GetTransportationDto>>(await _context.Transporations.RetrieveAllAsync(cancellationToken: cancellationToken));
            return ResponseResult.Success(Dtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetTransportationDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region PaginateDeletedTransportationsQuery
    public async Task<PaginationResponseModel<IEnumerable<GetTransportationDto>>> Handle(PaginateDeletedTransportationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<Transportation, object>> orderBy = t => new();

            switch (request.OrderBy)
            {
                case TransportationOrderBy.Id:
                    orderBy = t => t.Id;
                    break;
                case TransportationOrderBy.Model:
                    orderBy = t => t.Model;
                    break;
                default:
                    orderBy = t => t.Id;
                    break;
            }

            ISpecification<Transportation> asNoTrackingPaginateDeletedTransportationsSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsNoTrackingPaginateDeletedTransportationsSpecification),
                        request.PagNumber, request.PageSize, request.KeyWords, orderBy);



            IEnumerable<GetTransportationDto> Dtos = _mapper.Map<IEnumerable<GetTransportationDto>>(await _context.Transporations.RetrieveAllAsync(asNoTrackingPaginateDeletedTransportationsSpec, cancellationToken));

            ISpecification<Transportation> asNoTrackingGetAllDeletedTransportationsSpe =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsNoTrackingGetAllDeletedTransportationsSpecification));

            return PaginationResponseResult.Success(Dtos, message: _stringLocalizer[ResourcesKeys.Shared.Success],
                                                    pageSize: request.PageSize.Value,
                                                    currentPage: request.PagNumber.Value,
                                                    count: await _context.Transporations.CountAsync(asNoTrackingGetAllDeletedTransportationsSpe, cancellationToken));
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetTransportationDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region PaginateUnDeletedTransportationsQuery
    public async Task<PaginationResponseModel<IEnumerable<GetTransportationDto>>> Handle(PaginateUnDeletedTransportationsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<Transportation, object>> orderBy = t => new();

            switch (request.OrderBy)
            {
                case TransportationOrderBy.Id:
                    orderBy = t => t.Id;
                    break;
                case TransportationOrderBy.Model:
                    orderBy = t => t.Model;
                    break;
                default:
                    orderBy = t => t.Id;
                    break;
            }

            ISpecification<Transportation> asNoTrackingPaginateUnDeletedTransportationsSpec =
                _specificationsFactory.CreateTransporationsSpecifications(
                    typeof(AsNoTrackingPaginateUnDeletedTransportationsSpecification),
                        request.PagNumber, request.PageSize, request.KeyWords, orderBy);

            IEnumerable<GetTransportationDto> Dtos = _mapper.Map<IEnumerable<GetTransportationDto>>(await _context.Transporations.RetrieveAllAsync(asNoTrackingPaginateUnDeletedTransportationsSpec, cancellationToken));
            return PaginationResponseResult.Success(Dtos, message: _stringLocalizer[ResourcesKeys.Shared.Success],
                                                  pageSize: request.PageSize.Value,
                                                  currentPage: request.PagNumber.Value,
                                                  count: await _context.Transporations.CountAsync(cancellationToken: cancellationToken));
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetTransportationDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

}
