using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{ 

    public class TotalPrice : Value<TotalPrice>
    {
        public int Value { get; internal set; }

        protected TotalPrice() { }

        public TotalPrice(int totalPrice)
        {
            if (totalPrice < 0)
                throw new ArgumentException(
                    "Price cannot be negative",
                    nameof(totalPrice));

            Value = totalPrice;
        }

        public static TotalPrice FromInt(int totalPrice) 
        {
            return new TotalPrice(totalPrice);
        } 

        public static implicit operator int(TotalPrice totalPrice)
        {
            return totalPrice.Value;
        }
    }
}
