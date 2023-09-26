namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands.Handler;
public sealed class TripCommandsHandler
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    #endregion

    #region Ctor
    public TripCommandsHandler(
    IUnitOfWork context,
    ISpecificationsFactory specificationsFactory,
    IStringLocalizer<SharedResources> stringLocalizer
    )
    {
        _context = context;
        _specificationsFactory = specificationsFactory;
        _stringLocalizer = stringLocalizer;
    }
    #endregion


    #region Add Trip

    #endregion


    #region Update Trip

    #endregion


    #region Delete Trip

    #endregion

    #region Uudo Delete Trip


    #endregion
}
