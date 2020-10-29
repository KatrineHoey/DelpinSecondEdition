using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resource.Domain
{
    public class ResourceName:Value<ResourceName>
    {
        internal ResourceName (string value)
        {
            Value = value;
        }

        protected ResourceName() { }

        public string Value { get; internal set; }

        public static ResourceName FromString(string value)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentNullException(nameof(value));
            }
            return new ResourceName(value);
        }

        public static implicit operator string(ResourceName resourceName)
        {
            return resourceName.Value;
        }
    }
}
