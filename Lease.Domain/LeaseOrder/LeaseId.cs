using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class LeaseId : Value<LeaseId>
    {
        public Guid Value { get; internal set; }

        protected LeaseId() { }

        public LeaseId(Guid value)
        {
            if (value == default) 
            
                throw new ArgumentNullException(nameof(value), "Lease id cannot be empty");

                Value = value;
        }

        public static implicit operator Guid(LeaseId self) => self.Value;

        public static implicit operator LeaseId(string value) => new LeaseId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
