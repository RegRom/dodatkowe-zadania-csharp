using System;

namespace LegacyFighter.Dietary.Models.NewProducts
{
    public class OldProductCounter
    {
        public int? Counter { get; private set; }

        public OldProductCounter(int? counter)
        {
            Counter = counter;
        }
        
        public void IncrementCounter()
        {
            if (Counter == null)
            {
                throw new InvalidOperationException("null counter");
            }

            if (Counter + 1 < 0)
            {
                throw new InvalidOperationException("Negative counter");
            }

            Counter = Counter + 1;
        }

        public void DecrementCounter()
        {
            if (Counter == null)
            {
                throw new InvalidOperationException("null counter");
            }

            Counter = Counter - 1;
            if (Counter < 0)
            {
                throw new InvalidOperationException("Negative counter");
            }
        }
    }
}