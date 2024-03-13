namespace ExchangeRateService.ForeignExchangeMarket;

internal interface IExchangeRateProvider
{
    ValueTask<ExchangeRate[]> GetExchangeRatesAsync(IEnumerable<Currency>? currencies);
}