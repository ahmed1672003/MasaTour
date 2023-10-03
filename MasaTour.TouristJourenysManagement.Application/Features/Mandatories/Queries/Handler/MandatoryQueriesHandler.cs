using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;

namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Queries.Handler;
public sealed class MandatoryQueriesHandler :
    IRequestHandler<GetMandatoryByIdQuery, ResponseModel<GetMandatoryDto>>,
    IRequestHandler<GetAllMandatoriesQuery, ResponseModel<IEnumerable<GetMandatoryDto>>>,
    IRequestHandler<GetAllDeletedMandatoriesQuery, ResponseModel<IEnumerable<GetMandatoryDto>>>,
    IRequestHandler<GetAllUnDeletedMandatoriesQuery, ResponseModel<IEnumerable<GetMandatoryDto>>>,
    IRequestHandler<PaginateDeletedMandatoriesQuery, PaginationResponseModel<IEnumerable<GetMandatoryDto>>>,
    IRequestHandler<PaginateUnDeletedMandatoriesQuery, PaginationResponseModel<IEnumerable<GetMandatoryDto>>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public MandatoryQueriesHandler(
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

    #region Get Mandatory By Id
    public async Task<ResponseModel<GetMandatoryDto>> Handle(GetMandatoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // mandatory should be found
            ISpecification<Mandatory> asNoTrackingetGetMandatoryByIdSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingetGetMandatoryByIdSpecification), request.Id);

            if (!await _context.Mandatories.AnyAsync(asNoTrackingetGetMandatoryByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetMandatoryDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            GetMandatoryDto mandatoryDto = _mapper.Map<GetMandatoryDto>
                (await _context.Mandatories.RetrieveAsync(asNoTrackingetGetMandatoryByIdSpec, cancellationToken));

            return ResponseResult.Success(mandatoryDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetMandatoryDto>
                (message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Mandatories
    public async Task<ResponseModel<IEnumerable<GetMandatoryDto>>> Handle(GetAllMandatoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Mandatory> asNoTrackingGetAllMandatoriesSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingGetAllMandatoriesSpecification));

            if (!await _context.Mandatories.AnyAsync(asNoTrackingGetAllMandatoriesSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetMandatoryDto>>
                        (message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetMandatoryDto> mandatoryDtos = _mapper.Map<IEnumerable<GetMandatoryDto>>
                (await _context.Mandatories.RetrieveAllAsync(asNoTrackingGetAllMandatoriesSpec, cancellationToken));
            return ResponseResult.Success(mandatoryDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetMandatoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Deleted Mandatories
    public async Task<ResponseModel<IEnumerable<GetMandatoryDto>>> Handle(GetAllDeletedMandatoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Mandatory> asNoTrackingGetAllDeletedMandatoriesSpec = _specificationsFactory.CreateMandatorySpecifications(typeof(AsNoTrackingGetAllDeletedMandatoriesSpecification));

            if (!await _context.Mandatories.AnyAsync(asNoTrackingGetAllDeletedMandatoriesSpec, cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetMandatoryDto>>
                        (message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetMandatoryDto> mandatoryDtos = _mapper.Map<IEnumerable<GetMandatoryDto>>
                (await _context.Mandatories.RetrieveAllAsync(asNoTrackingGetAllDeletedMandatoriesSpec, cancellationToken));

            return ResponseResult.Success(mandatoryDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetMandatoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All UnDeleted Mandatories
    public async Task<ResponseModel<IEnumerable<GetMandatoryDto>>> Handle(GetAllUnDeletedMandatoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Mandatories.AnyAsync(cancellationToken: cancellationToken))
                return ResponseResult.NotFound<IEnumerable<GetMandatoryDto>>
                         (message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            IEnumerable<GetMandatoryDto> mandatoryDtos = _mapper.Map<IEnumerable<GetMandatoryDto>>
                    (await _context.Mandatories.RetrieveAllAsync(cancellationToken: cancellationToken));
            return ResponseResult.Success(mandatoryDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetMandatoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Paginate Deleted Mandatories
    public async Task<PaginationResponseModel<IEnumerable<GetMandatoryDto>>> Handle(PaginateDeletedMandatoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<Mandatory, object>> orderBy = mandatory => new();
            switch (request.OrderBy)
            {
                case MandatoryOrderBy.Id:
                    orderBy = mandatory => mandatory.Id;
                    break;

                case MandatoryOrderBy.NameAR:
                    orderBy = mandatory => mandatory.NameAR;
                    break;
                case MandatoryOrderBy.NameEN:
                    orderBy = mandatory => mandatory.NameEN;
                    break;
                case MandatoryOrderBy.NameDE:
                    orderBy = mandatory => mandatory.NameDE;
                    break;
                default:
                    orderBy = mandatory => mandatory.CreatedAt;
                    break;
            }
            ISpecification<Mandatory> asNoTrackingPaginateDeletedMandatoriesSpec = _specificationsFactory.
                    CreateMandatorySpecifications(typeof(AsNoTrackingPaginateDeletedMandatoriesSpecification),
                            request.PageNumber.Value, request.PageSize.Value, request.KeyWords, orderBy);

            IEnumerable<GetMandatoryDto> mandatoryDtos = _mapper.Map<IEnumerable<GetMandatoryDto>>
                    (await _context.Mandatories.RetrieveAllAsync(asNoTrackingPaginateDeletedMandatoriesSpec, cancellationToken));

            ISpecification<Mandatory> asNoTrackingGetAllDeletedMandatoriesSpec = _specificationsFactory.
                    CreateMandatorySpecifications(typeof(AsNoTrackingGetAllDeletedMandatoriesSpecification));

            return PaginationResponseResult.Success(mandatoryDtos,
                                            pageSize: request.PageSize.Value,
                                            currentPage: request.PageNumber.Value,
                                            count: await _context.Mandatories.CountAsync(asNoTrackingGetAllDeletedMandatoriesSpec, cancellationToken));
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetMandatoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Paginate UnDeleted Mandatories
    public async Task<PaginationResponseModel<IEnumerable<GetMandatoryDto>>> Handle(PaginateUnDeletedMandatoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<Mandatory, object>> orderBy = mandatory => new();
            switch (request.OrderBy)
            {
                case MandatoryOrderBy.Id:
                    orderBy = mandatory => mandatory.Id;
                    break;

                case MandatoryOrderBy.NameAR:
                    orderBy = mandatory => mandatory.NameAR;
                    break;
                case MandatoryOrderBy.NameEN:
                    orderBy = mandatory => mandatory.NameEN;
                    break;
                case MandatoryOrderBy.NameDE:
                    orderBy = mandatory => mandatory.NameDE;
                    break;
                default:
                    orderBy = mandatory => mandatory.CreatedAt;
                    break;
            }
            ISpecification<Mandatory> asNoTrackingPaginateUnDeletedMandatoriesSpec = _specificationsFactory.
                CreateMandatorySpecifications(typeof(AsNoTrackingPaginateUnDeletedMandatoriesSpecification),
                        request.PageNumber.Value, request.PageSize.Value, request.KeyWords, orderBy);

            IEnumerable<GetMandatoryDto> mandatoryDtos = _mapper.Map<IEnumerable<GetMandatoryDto>>
                (await _context.Mandatories.RetrieveAllAsync(asNoTrackingPaginateUnDeletedMandatoriesSpec, cancellationToken));
            return PaginationResponseResult.Success(mandatoryDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success],
                pageSize: request.PageSize.Value,
                currentPage: request.PageNumber.Value,
                count: await _context.Mandatories.CountAsync(cancellationToken: cancellationToken));
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetMandatoryDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
