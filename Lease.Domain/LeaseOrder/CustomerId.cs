using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class CustomerId : Value<CustomerId>
    {
        public Guid Value { get; internal set; }

        protected CustomerId() { }

        public CustomerId(Guid value)
        {
            if (value == default)

                throw new ArgumentNullException(nameof(value), "CustomerId cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(CustomerId self) => self.Value;

        public static implicit operator CustomerId(string value) => new CustomerId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
