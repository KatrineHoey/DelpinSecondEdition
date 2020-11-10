using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resource.Domain
{
    public class ResourceNo:Value<ResourceNo>
    {
        internal ResourceNo(int resourceNo)
        {
            if (resourceNo == default)
            {
                throw new ArgumentNullException(nameof(resourceNo), "ResourceNo can't be empty");
            }

            Value = resourceNo;
        }

        protected ResourceNo() { }

        public int Value { get; internal set; }

        public static ResourceNo FromInt(int text)
        {
            return new ResourceNo(Convert.ToInt32(text));
        }

        public static implicit operator int(ResourceNo resourceNo)
        {
            return resourceNo.Value;
        }
    }
}
