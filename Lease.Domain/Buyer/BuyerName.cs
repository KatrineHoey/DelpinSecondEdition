using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class BuyerName : Value<BuyerName>
    {
        public string Value { get; internal set; }

        public BuyerName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected BuyerName()
        {
        }

        public static BuyerName FromString(string name)
        {
            if (name.IsEmpty())
                throw new ArgumentNullException(nameof(name));

            return new BuyerName(name);
        }

        public static implicit operator string(BuyerName name)
        {
            return name.Value;
        }
    }
}
