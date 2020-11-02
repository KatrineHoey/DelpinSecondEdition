using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class TotalPrice : Value<TotalPrice>
    {
        public decimal Value { get; }

        protected TotalPrice() { }

        public TotalPrice(decimal totalPrice)
        {
            if (totalPrice < 0)
                throw new ArgumentException(
                    "Price cannot be negative",
                    nameof(totalPrice));

            Value = totalPrice;
        }

        public static TotalPrice FromDecimal(decimal totalPrice) 
        {
            return new TotalPrice(totalPrice);

        } 

        public static implicit operator decimal(TotalPrice totalPrice)
        {
            return totalPrice.Value;
        }
    }
}
