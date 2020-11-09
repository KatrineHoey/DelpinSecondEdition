using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class IsDeleted : Value<IsDeleted>
    {
        public bool Value { get; internal set; }

        public IsDeleted(bool value)
        {
            Value = value;
        }

        protected IsDeleted() { }

        public static IsDeleted FromString(bool isDeleted)
        {
            return new IsDeleted(Convert.ToBoolean(isDeleted));
        }


        public static implicit operator bool(IsDeleted isDeleted) => isDeleted.Value;


    }
}
