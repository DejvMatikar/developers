﻿namespace ExchangeRateService.Domain;

internal record ExchangeRate(Currency SourceCurrency, Currency TargetCurrency, decimal Value)
{
    public override string ToString() => $"{SourceCurrency}/{TargetCurrency}={Value}";
}