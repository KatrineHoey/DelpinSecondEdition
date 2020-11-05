using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class IsReturned : Value<IsReturned>
    {
        public bool Value { get; internal set; }

        public IsReturned(bool value) 
        {
            Value = value;
        } 

        protected IsReturned() { }

        public static implicit operator bool(IsReturned isReturned)
        {
            return isReturned.Value;
        }

        public static IsReturned FromBool(bool isReturned)
        {
            return new IsReturned(isReturned);
        } 
    }
}
