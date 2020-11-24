using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class ResourceName : Value<ResourceName>
    {
        public string Value { get; internal set; }

        public ResourceName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected ResourceName()
        {
        }

        public static ResourceName FromString(string ResourceName)
        {
            if (ResourceName.IsEmpty())
                throw new ArgumentNullException(nameof(ResourceName));

            return new ResourceName(ResourceName);
        }

        public static implicit operator string(ResourceName ResourceName)
        {
            return ResourceName.Value;
        }
    }
}
