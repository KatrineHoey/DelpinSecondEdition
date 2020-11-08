using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class LeaseOrderId : Value<LeaseOrderId>
    {
        public Guid Value { get; internal set; }

        protected LeaseOrderId() { }

        public LeaseOrderId(Guid value)
        {
            if (value == default) 
            
                throw new ArgumentNullException(nameof(value), "Lease id cannot be empty");

                Value = value;
        }

        public static implicit operator Guid(LeaseOrderId self) => self.Value;

        public static implicit operator LeaseOrderId(string value) => new LeaseOrderId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
