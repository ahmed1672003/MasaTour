namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Queries.Handler;
public sealed class CommentQueriesHandler :
    IRequestHandler<GetAllCommentByTripIdQuery, ResponseModel<IEnumerable<GetCommentDto>>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public CommentQueriesHandler(
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

    #region Get All Comments By TripId
    public async Task<ResponseModel<IEnumerable<GetCommentDto>>> Handle(GetAllCommentByTripIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Comment> asNoTrackingGetAllCommentsByTripIdSpec = _specificationsFactory.CreateCommentsSpecifications(typeof(AsNoTrackingGetAllCommentsByTripIdSpecification), request.TripId);
            IEnumerable<GetCommentDto> commentDtos = _mapper.Map<IEnumerable<GetCommentDto>>(await _context.Comments.RetrieveAllAsync(asNoTrackingGetAllCommentsByTripIdSpec, cancellationToken));
            return ResponseResult.Success(commentDtos, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetCommentDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
