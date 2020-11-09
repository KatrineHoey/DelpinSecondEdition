using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class Quantity : Value<Quantity>
    {
        public int Value { get; internal set; }

        public Quantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentNullException(
                    nameof(quantity), "Quantity most be valid.");

            Value = quantity;
        }

        // Satisfy the serialization requirements 
        protected Quantity()
        {
        }

        public static Quantity FromString(string quantity)
        {

            if (quantity.IsEmpty())
                throw new ArgumentNullException(nameof(quantity));

            return new Quantity(Convert.ToInt32(quantity));
        }

        public static implicit operator int(Quantity quantity)
        {
            return quantity.Value;
        }
    }
}
