using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resource.Domain
{
    public class IsDeleted : Value<IsDeleted>
    {
        internal IsDeleted(bool value)
        {
            Value = value;
        }

        public bool Value { get; internal set; } = false;

        protected IsDeleted() { }

        public static IsDeleted FromBool(bool isDeleted)
        {
            return new IsDeleted(isDeleted);
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
