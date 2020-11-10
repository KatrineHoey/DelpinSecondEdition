using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class LeaseOrderLineId : Value<LeaseOrderLineId>
    {
        public LeaseOrderLineId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected LeaseOrderLineId() { }

        public static implicit operator Guid(LeaseOrderLineId self) => self.Value;

        public static implicit operator LeaseOrderLineId(string value) => new LeaseOrderLineId(Guid.Parse(value));

        public override string ToString() => Value.ToString();














    }
}
