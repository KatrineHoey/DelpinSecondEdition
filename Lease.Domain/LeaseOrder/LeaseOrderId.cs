using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lease.Domain
{
    public class LeaseOrderId : Value<LeaseOrderId>
    {
        public Guid LeaseOrderIdValue { get; internal set; }

        protected LeaseOrderId() { }

        public LeaseOrderId(Guid value)
        {
            if (value == default) 
            
                throw new ArgumentNullException(nameof(value), "Lease id cannot be empty");

                LeaseOrderIdValue = value;
        }

        public static implicit operator Guid(LeaseOrderId self) => self.LeaseOrderIdValue;

        public static implicit operator LeaseOrderId(string value) => new LeaseOrderId(Guid.Parse(value));

        public override string ToString() => LeaseOrderIdValue.ToString();
    }
}
