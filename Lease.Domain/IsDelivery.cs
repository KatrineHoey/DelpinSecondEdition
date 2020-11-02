using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class IsDelivery : Value<IsDelivery>
    {
        public bool Value { get; }

        public IsDelivery(bool value)
        {
            Value = value;
        } 

        public static implicit operator bool(IsDelivery isDelivery) => isDelivery.Value;

        protected IsDelivery() { }

        public static IsDelivery FromBool(bool isDelivery)
        {
            return new IsDelivery(isDelivery);
        }
    }
}
