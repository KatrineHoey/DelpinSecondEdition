using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class IsPaid : Value<IsPaid>
    {
        public bool Value { get; internal set; }

        protected IsPaid() { }

        public static IsPaid FromBool(bool isPaid)
        {
            return new IsPaid(isPaid);
        }

        public IsPaid(bool value) => Value = value;

        public static implicit operator bool(IsPaid isPaid) => isPaid.Value;

        public static IsPaid NotPaid => new IsPaid();
    }
}
