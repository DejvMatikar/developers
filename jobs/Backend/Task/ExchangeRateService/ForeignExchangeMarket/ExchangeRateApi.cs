namespace ExchangeRateService.ForeignExchangeMarket;

internal class ExchangeRateApi : IApiRoute
{ 
    public void Register(RouteGroupBuilder group)
    {
        group
            .MapGet("/exchangeRate", GetExchangeRatesAsync)
            .Produces<ExchangeRateResponse>()
            .WithName("GetExchangeRates")
            .WithOpenApi();
    }

    private async ValueTask<ExchangeRateResponse> GetExchangeRatesAsync(
        [AsParameters] ExchangeRateFilterRequest filter,
        IExchangeRateProvider exchangeRateProvider,
        IMapper mapper)
    {
        var currencies = filter.CurrencyCode is not null 
            ? mapper.Map<IEnumerable<Currency>>(filter.CurrencyCode)
            : null;
        var rates = await exchangeRateProvider.GetExchangeRatesAsync(currencies);
        return mapper.Map<ExchangeRateResponse>(rates);
    }
}