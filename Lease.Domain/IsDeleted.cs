using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class IsDeleted : Value<IsDeleted>
    {
        public bool Value { get; internal set; }

        protected IsDeleted() { }

        public static IsDeleted FromBool(bool isDeleted)
        {
            return new IsDeleted(isDeleted);
        }

        public IsDeleted(bool value) => Value = value;

        public static implicit operator bool(IsDeleted isDeleted) => isDeleted.Value;

        public static IsDeleted NotDeleted => new IsDeleted();
    }
}
