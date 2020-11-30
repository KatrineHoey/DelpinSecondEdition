using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resource.Domain
{
    public class ResourcePrice :Value<ResourcePrice>
    {
        public int Value { get; internal set; }

        protected ResourcePrice() { }

        internal ResourcePrice(int resourcePrice)
        {
            if (resourcePrice <0)
            {
                throw new ArgumentNullException(nameof(resourcePrice), "Price can't be negative");
            }

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
