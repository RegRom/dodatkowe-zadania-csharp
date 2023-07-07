using System;

namespace LegacyFighter.Dietary.Models.NewProducts
{
    public class Counter
    {
        public int? Value { get; private set; }
        
        public bool IsPositive => Value is > 0;

        public Counter(int? value)
        {
            Value = value;
        }
        
        public Counter IncrementCounter()
        {
            if (Value == null)
            {
                throw new InvalidOperationException("null counter");
            }

            if (Value + 1 < 0)
            {
                throw new InvalidOperationException("Negative counter");
            }

            return new Counter(Value + 1);
        }

        public Counter DecrementCounter()
        {
            if (Value == null)
            {
                throw new InvalidOperationException("null counter");
            }
            
            if (Value <= 0)
            {
                throw new InvalidOperationException("Negative counter");
            }
            
            return new Counter(Value - 1);
        }
    }
}