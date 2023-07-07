using System;

namespace LegacyFighter.Dietary.Models.NewProducts
{
    public class OldProduct
    {
        private Counter _counter;
        private Price _price;
        private readonly Description _description;
        
        public Guid SerialNumber { get; private set; } = Guid.NewGuid();
        
        public int? Counter => _counter.Value;
        public decimal? Price => _price.Value;

        public OldProduct(decimal? price, string desc, string longDesc, int? counter)
        {
            _price = new Price(price);
            _description = new Description(desc, longDesc);
            _counter = new Counter(counter);
        }

        public void DecrementCounter()
        {
            if (_price.IsValid)
            {
                _counter = _counter.DecrementCounter();
            }
            else
            {
                throw new InvalidOperationException("Invalid price");
            }
        }

        public void IncrementCounter()
        {
            if (_price.IsValid)
            {
                _counter = _counter.IncrementCounter();
            }
            else
            {
                throw new InvalidOperationException("Invalid price");
            }
        }

        public void ChangePriceTo(decimal? newPrice)
        {
            if (_counter == null)
            {
                throw new InvalidOperationException("null counter");
            }

            if (_counter.IsPositive)
            {
                _price = NewProducts.Price.ChangePriceTo(newPrice);
            }
        }

        public void ReplaceCharFromDesc(string charToReplace, string replaceWith)
        {
            _description.ReplaceCharFromDesc(charToReplace, replaceWith);
        }

        public string FormatDesc()
        {
            return _description.FormatDesc();
        }
    }
}