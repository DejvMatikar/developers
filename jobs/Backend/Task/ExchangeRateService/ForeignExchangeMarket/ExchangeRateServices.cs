namespace ExchangeRateService.ForeignExchangeMarket;

internal class ExchangeRateServices : IServices
{
    public void Register(IServiceCollection services)
    {
        services.AddTransient<IExchangeRateProvider, ExchangeRateProvider>();
    }
}