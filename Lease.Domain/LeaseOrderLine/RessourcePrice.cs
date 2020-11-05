using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class RessourcePrice :Value<RessourcePrice>
    {
        public decimal Value { get; internal set; }

        protected RessourcePrice() { }

        public RessourcePrice(decimal ressourcePrice)
        {
            if (ressourcePrice < 0)
                throw new ArgumentException(
                    "RessourcePrice cannot be negative",
                    nameof(ressourcePrice));

            Value = ressourcePrice;
        }

        public static RessourcePrice FromDecimal(decimal ressourcePrice)
        {
            return new RessourcePrice(ressourcePrice);

        }

        public static implicit operator decimal(RessourcePrice ressourcePrice)
        {
            return ressourcePrice.Value;
        }
    }
}

