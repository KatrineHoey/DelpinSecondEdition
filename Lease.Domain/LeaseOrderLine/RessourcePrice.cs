using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class RessourcePrice :Value<RessourcePrice>
    {
        public int Value { get; internal set; }

        protected RessourcePrice() { }

        public RessourcePrice(int ressourcePrice)
        {
            if (ressourcePrice < 0)
                throw new ArgumentException(
                    "RessourcePrice cannot be negative",
                    nameof(ressourcePrice));

            Value = ressourcePrice;
        }

        public static RessourcePrice FromInt(int ressourcePrice)
        {
            return new RessourcePrice(ressourcePrice);

        }

        public static implicit operator int(RessourcePrice ressourcePrice)
        {
            return ressourcePrice.Value;
        }
    }
}

