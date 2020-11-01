using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lease.Domain
{
    public class Street : Value<Street>
    {
        public string Value { get; }

        public Street(string street)
        {
            Value = street;
        }

        // Satisfy the serialization requirements 
        protected Street()
        {
        }

        public static Street FromString(string street)
        {
            if (street.IsEmpty())
                throw new ArgumentNullException(nameof(street));

            return new Street(street);
        }

        public static implicit operator string(Street street)
        {
            return street.Value;
        }
    }
}
