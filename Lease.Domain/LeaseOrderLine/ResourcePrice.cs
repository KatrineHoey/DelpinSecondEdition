using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class ResourcePrice :Value<ResourcePrice>
    {
        public int Value { get; internal set; }

        protected ResourcePrice() { }

        public ResourcePrice(int resourcePrice)
        {
            if (resourcePrice < 0)
                throw new ArgumentException(
                    "ResourcePrice cannot be negative",
                    nameof(resourcePrice));

            Value = resourcePrice;
        }

        public static ResourcePrice FromInt(int resourcePrice)
        {
            return new ResourcePrice(resourcePrice);

        }

        public static implicit operator int(ResourcePrice resourcePrice)
        {
            return resourcePrice.Value;
        }
    }
}

