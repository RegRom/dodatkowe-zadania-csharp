using System;

namespace LegacyFighter.Dietary.Models.NewProducts;

public class Price
{
    public Price(decimal? price)
    {
        Value = price;
    }

    public decimal? Value { get; }
    
    public static Price ChangePriceTo(decimal? newPrice)
    {
        if (newPrice == null)
        {
            throw new InvalidOperationException("new price null");
        }

        return new Price(newPrice);
    }

    public bool IsValid => Value is > 0;
}