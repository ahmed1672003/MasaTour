using MasaTour.TouristTripsManagement.Services.Dtos.Currencies;

namespace MasaTour.TouristTripsManagement.Services.Services.Contracts;
public interface IFastForexService
{
    Task<GetMultiCurrenciesDto> FetchMultiAsync();
}
