using System;

namespace LegacyFighter.Dietary.Models.NewProducts
{
    public class OldProduct
    {
        public Guid SerialNumber { get; private set; } = Guid.NewGuid();
        public decimal? Price { get; private set; }
        private OldProductDescription OldProductDescription { get; set; }
        private readonly OldProductCounter _counter;
        public int? Counter => _counter.Counter;

        public OldProduct(decimal? price, string desc, string longDesc, int? counter)
        {
            Price = price;
            OldProductDescription = new OldProductDescription(desc, longDesc);
            _counter = new OldProductCounter(counter);
        }

        public void DecrementCounter()
        {
            if (Price is not null && Price > 0)
            {
                _counter.DecrementCounter();
            }
            else
            {
                throw new InvalidOperationException("Invalid price");
            }
        }

        public void IncrementCounter()
        {
            if (Price > 0)
            {
                _counter.IncrementCounter();
            }
            else
            {
                throw new InvalidOperationException("Invalid price");
            }
        }

        public void ChangePriceTo(decimal? newPrice)
        {
            if (Counter == null)
            {
                throw new InvalidOperationException("null counter");
            }

            if (Counter > 0)
            {
                if (newPrice == null)
                {
                    throw new InvalidOperationException("new price null");
                }

                Price = newPrice;
            }
        }

        public void ReplaceCharFromDesc(string charToReplace, string replaceWith)
        {
            OldProductDescription.ReplaceCharFromDesc(charToReplace, replaceWith);
        }

        public string FormatDesc()
        {
            return OldProductDescription.FormatDesc();
        }
    }
}