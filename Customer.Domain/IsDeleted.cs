using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain
{
    public class IsDeleted : Value<IsDeleted>
    {
        internal IsDeleted(bool value)
        {
            Value = value;
        }

        public bool Value { get; internal set; } = false;

        // Satisfy the serialization requirements 
        protected IsDeleted() { }

        public static IsDeleted FromString(string isDeleted)
        {
            return new IsDeleted(Convert.ToBoolean(isDeleted));
        }

        public static implicit operator bool(IsDeleted isDeleted)
        {            
            return isDeleted.Value;
        }

        public static IsDeleted NotDeleted()
        {
            return new IsDeleted();
        }
    }
}
