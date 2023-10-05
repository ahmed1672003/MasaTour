namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Commands.Handler;
public sealed class CommentCommandsHandler :
    IRequestHandler<AddCommentCommand, ResponseModel<GetCommentDto>>,
    IRequestHandler<UpdateCommentCommand, ResponseModel<GetCommentDto>>,
    IRequestHandler<DeleteCommentByIdCommand, ResponseModel<GetCommentDto>>,
    IRequestHandler<UndoDeleteCommentByIdCommand, ResponseModel<GetCommentDto>>

{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public CommentCommandsHandler(
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

    #region Add Comment
    public async Task<ResponseModel<GetCommentDto>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Comment comment = _mapper.Map<Comment>(request.Dto);
            await _context.Comments.CreateAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetCommentDto commentDto = _mapper.Map<GetCommentDto>(comment);
            return ResponseResult.Created(commentDto, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCommentDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Update Comment
    public async Task<ResponseModel<GetCommentDto>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Comment> asNoTrackingGetCommentByIdSpec = _specificationsFactory.CreateCommentsSpecifications(typeof(AsTrackingGetCommentByIdSpecification), request.Dto.CommentId);
            if (!await _context.Comments.AnyAsync(asNoTrackingGetCommentByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCommentDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Comment> asTrackingGetCommentByIdSpec = _specificationsFactory.CreateCommentsSpecifications(typeof(AsTrackingGetCommentByIdSpecification), request.Dto.CommentId);
            Comment comment = await _context.Comments.RetrieveAsync(asNoTrackingGetCommentByIdSpec, cancellationToken);

            comment.Content = request.Dto.Content;
            await _context.SaveChangesAsync(cancellationToken);

            GetCommentDto commentDto = _mapper.Map<GetCommentDto>(comment);
            return ResponseResult.Success(commentDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);

        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCommentDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete Comment By Id
    public async Task<ResponseModel<GetCommentDto>> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Comment> asNoTrackingGetCommentByIdSpec = _specificationsFactory.CreateCommentsSpecifications(typeof(AsTrackingGetCommentByIdSpecification), request.CommentId);
            if (!await _context.Comments.AnyAsync(asNoTrackingGetCommentByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCommentDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            Comment comment = await _context.Comments.RetrieveAsync(asNoTrackingGetCommentByIdSpec, cancellationToken);
            await _context.Comments.DeleteAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetCommentDto commetDto = _mapper.Map<GetCommentDto>(comment);
            return ResponseResult.Success(commetDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCommentDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Undo Delete Comment By Id
    public async Task<ResponseModel<GetCommentDto>> Handle(UndoDeleteCommentByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Comment> asTrackingGetDeletedCommentByIdSpec = _specificationsFactory.CreateCommentsSpecifications(typeof(AsTrackingGetDeletedCommentByIdSpecification), request.CommentId);
            if (!await _context.Comments.AnyAsync(asTrackingGetDeletedCommentByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetCommentDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            Comment comment = await _context.Comments.RetrieveAsync(asTrackingGetDeletedCommentByIdSpec, cancellationToken);
            _context.UndoDeleted(ref comment);
            await _context.SaveChangesAsync(cancellationToken);

            GetCommentDto commentDto = _mapper.Map<GetCommentDto>(comment);
            return ResponseResult.Success(commentDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetCommentDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
