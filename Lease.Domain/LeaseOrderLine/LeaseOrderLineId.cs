using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class LeaseOrderLineId : Value<LeaseOrderLineId>
    {
        //public Guid Value { get; internal set; }

        //protected LeaseOrderLineId() { }

        //public LeaseOrderLineId(Guid value)
        //{
        //    if (value == default)

        //        throw new ArgumentNullException(nameof(value), "Lease id cannot be empty");

        //    Value = value;
        //}

        //public static implicit operator Guid(LeaseOrderLineId self) => self.Value;

        //public static implicit operator LeaseOrderLineId(string value) => new LeaseOrderLineId(Guid.Parse(value));

        //public override string ToString() => Value.ToString();



        //GammeltWin
        public LeaseOrderLineId(Guid value) => Value = value;

        public Guid Value { get; }

        protected LeaseOrderLineId() { }

        public static implicit operator Guid(LeaseOrderLineId self) => self.Value;

        public static implicit operator LeaseOrderLineId(string value) => new LeaseOrderLineId(Guid.Parse(value));

        public override string ToString() => Value.ToString();














    }
}
