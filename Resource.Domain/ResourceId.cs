using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resource.Domain
{
    public class ResourceId : Value<ResourceId>
    {
        public ResourceId(Guid value)
        {
            if (value==default)
            {
                throw new ArgumentNullException(nameof(value), "Resource Id can't be empty");
            }
            Value = value;
        }

        public Guid Value { get; internal set; }

        public static implicit operator Guid(ResourceId self)
        {
            return self.Value;
        }

        public static implicit operator ResourceId(string value)
        {
            return new ResourceId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
