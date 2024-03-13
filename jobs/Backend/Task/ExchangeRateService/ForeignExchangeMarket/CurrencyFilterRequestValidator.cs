namespace ExchangeRateService.ForeignExchangeMarket;

internal class CurrencyFilterRequestValidator : AbstractValidator<ExchangeRateFilterRequest>
{
    public CurrencyFilterRequestValidator()
    {
        RuleForEach(x => x.CurrencyCode)
            .NotNull()
            .Matches("^[A-Z]{3}$")
            .WithMessage("Only three-letter ISO 4217 code of the currency is supported.");
    }
}