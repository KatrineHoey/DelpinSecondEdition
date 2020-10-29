using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class IsDelivery : Value<IsDelivery>
    {
        public bool Value { get; internal set; }

        protected IsDelivery() { }

        public static IsDelivery FromBool(bool isDelivery)
        {
            return new IsDelivery(isDelivery);
        }

        public IsDelivery(bool value) => Value = value;

        public static implicit operator bool(IsDelivery isDelivery) => isDelivery.Value;

        public static IsDelivery NoDelivery => new IsDelivery();
    }
}
