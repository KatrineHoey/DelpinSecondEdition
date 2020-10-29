using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain
{
    public class FullName : Value<FullName>
    {
        internal FullName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected FullName()
        {
        }

        public string Value { get; }

        public static FullName FromString(string fullName)
        {
            if (fullName.IsEmpty())
                throw new ArgumentNullException(nameof(fullName));

            return new FullName(fullName);
        }

        public static implicit operator string(FullName fullName)
        {
            return fullName.Value;
        }
    }
}
