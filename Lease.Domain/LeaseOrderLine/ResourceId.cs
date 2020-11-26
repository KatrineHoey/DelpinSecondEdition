using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class ResourceId : Value<ResourceId>
    {
        public ResourceId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected ResourceId() { }

        public static implicit operator Guid(ResourceId self) => self.Value;

        public static implicit operator ResourceId(string value) => new ResourceId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
