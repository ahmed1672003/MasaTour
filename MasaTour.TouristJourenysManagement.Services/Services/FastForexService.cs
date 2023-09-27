using System.Net.Http.Json;

using MasaTour.TouristTripsManagement.Services.Dtos.Currencies;

namespace MasaTour.TouristTripsManagement.Services.Services;
public sealed class FastForexService : IFastForexService
{
    private readonly FastForexSettings _fastForexSettings;
    private readonly IHttpClientFactory _httpClientFactory;
    public FastForexService(IOptions<FastForexSettings> options, IHttpClientFactory httpClientFactory)
    {
        _fastForexSettings = options.Value;
        _httpClientFactory = httpClientFactory;
    }
    public async Task<GetMultiCurrenciesDto> FetchMultiAsync()
    {
        try
        {
            using HttpClient httpClient = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.fastforex.io/fetch-multi?from={_fastForexSettings.From}&to={_fastForexSettings.To}&api_key={_fastForexSettings.ApiKey}"),
                Headers =
                {
                    { "accept", "application/json" },
                },

            };
            using HttpResponseMessage response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            GetMultiCurrenciesDto multiCurrenciesDto = await response.Content.ReadFromJsonAsync<GetMultiCurrenciesDto>();
            return multiCurrenciesDto;
        }
        catch
        {
            throw new HttpRequestException();
        }
    }
}
