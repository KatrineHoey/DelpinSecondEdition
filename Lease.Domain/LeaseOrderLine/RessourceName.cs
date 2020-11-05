using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class RessourceName : Value<RessourceName>
    {
        public string Value { get; internal set; }

        internal RessourceName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected RessourceName()
        {
        }

        public static RessourceName FromString(string ressourceName)
        {
            if (ressourceName.IsEmpty())
                throw new ArgumentNullException(nameof(ressourceName));

            return new RessourceName(ressourceName);
        }

        public static implicit operator string(RessourceName ressourceName)
        {
            return ressourceName.Value;
        }
    }
}
