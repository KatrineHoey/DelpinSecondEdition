using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class BuyerId : Value<BuyerId>
    {
        public BuyerId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected BuyerId() { }

        public static implicit operator Guid(BuyerId self) => self.Value;

        public static implicit operator BuyerId(string value) => new BuyerId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
