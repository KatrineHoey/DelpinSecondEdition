using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class LineTotalPrice :Value<LineTotalPrice>
    {
        public decimal Value { get; internal set; }

        protected LineTotalPrice() { }

        public LineTotalPrice(decimal lineTotalPrice)
        {
            if (lineTotalPrice < 0)
                throw new ArgumentException(
                    "LineTotalPrice cannot be negative",
                    nameof(lineTotalPrice));

            Value = lineTotalPrice;
        }

        public static LineTotalPrice FromDecimal(decimal lineTotalPrice)
        {
            return new LineTotalPrice(lineTotalPrice);

        }

        public static implicit operator decimal(LineTotalPrice lineTotalPrice)
        {
            return lineTotalPrice.Value;
        }
    }
}
