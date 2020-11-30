using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class LineTotalPrice :Value<LineTotalPrice>
    {
        public int Value { get; internal set; }

        protected LineTotalPrice() { }

        public LineTotalPrice(int lineTotalPrice)
        {
            if (lineTotalPrice < 0)
                throw new ArgumentException(
                    "LineTotalPrice cannot be negative",
                    nameof(lineTotalPrice));

            Value = lineTotalPrice;
        }

        public static LineTotalPrice Fromint(int lineTotalPrice)
        {
            return new LineTotalPrice(lineTotalPrice);

        }

        public static implicit operator int(LineTotalPrice lineTotalPrice)
        {
            return lineTotalPrice.Value;
        }
    }
}
