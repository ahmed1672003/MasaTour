namespace MasaTour.TouristTripsManagement.Services.Dtos.Currencies;
public class GetMultiCurrenciesDto
{
    public GetCurrenciesResults Results { get; set; }
    public string Updated { get; set; }
}

public class GetCurrenciesResults
{
    public decimal EUR { get; set; }
    public decimal GBP { get; set; }
    public decimal EGP { get; set; }
}