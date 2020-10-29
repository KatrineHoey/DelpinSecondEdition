using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resource.Domain
{
    class ResourcePrice :Value<ResourcePrice>
    {
        public decimal Value { get; internal set; }

        protected ResourcePrice() { }

        internal ResourcePrice(decimal resourcePrice)
        {
            if (resourcePrice <0)
            {
                throw new ArgumentNullException(nameof(resourcePrice), "Price can't be negative");
            }

            Value = resourcePrice;
        }

        public static ResourcePrice FromDecimal(decimal resourcePrice)
        {
            return new ResourcePrice(resourcePrice);
        }

        public static implicit operator decimal(ResourcePrice resourcePrice)
        {
            return resourcePrice.Value;
        }
    }
}
