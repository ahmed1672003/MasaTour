namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Commands.Handler;
public sealed class TransportationClassCommandsHandler :
    IRequestHandler<AddTransportationClassCommand, ResponseModel<GetTransportationClassDto>>,
    IRequestHandler<UpdateTransportationClassCommand, ResponseModel<GetTransportationClassDto>>,
    IRequestHandler<DeleteTransportationClassByIdCommand, ResponseModel<GetTransportationClassDto>>,
    IRequestHandler<UndoDeleteTransportationClassByIdCommand, ResponseModel<GetTransportationClassDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TransportationClassCommandsHandler(
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

    #region Add TransportationClass
    public Task<ResponseModel<GetTransportationClassDto>> Handle(AddTransportationClassCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Update TransportationClass
    public Task<ResponseModel<GetTransportationClassDto>> Handle(UpdateTransportationClassCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Delete TransportationClass By Id
    public Task<ResponseModel<GetTransportationClassDto>> Handle(DeleteTransportationClassByIdCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Undo Delete TransportationClass By Id
    public Task<ResponseModel<GetTransportationClassDto>> Handle(UndoDeleteTransportationClassByIdCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    #endregion
}
