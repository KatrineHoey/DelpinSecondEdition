using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain
{
    public class CustomerId : Value<CustomerId>
    {
        public CustomerId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Customer id cannot be empty");

            Value = value;
        }

        public Guid Value { get; }

        public static implicit operator Guid(CustomerId self)
        {
            return self.Value;
        }
    }
}
