using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class RessourceId : Value<RessourceId>
    {
        public RessourceId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected RessourceId() { }

        public static implicit operator Guid(RessourceId self) => self.Value;

        public static implicit operator RessourceId(string value) => new RessourceId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
