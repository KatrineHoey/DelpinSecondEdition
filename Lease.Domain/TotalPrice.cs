using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class TotalPrice : Value<TotalPrice>
    {
        public decimal Price { get; internal set; }

        protected TotalPrice() { }

        private TotalPrice(decimal totalPrice)
        {
            if (totalPrice < 0)
                throw new ArgumentException(
                    "Price cannot be negative",
                    nameof(totalPrice));

            Price = totalPrice;
        }

        public static TotalPrice FromDecimal(decimal totalPrice) => new TotalPrice(totalPrice);
    }
}
