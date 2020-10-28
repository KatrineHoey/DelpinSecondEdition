using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class City : Value<City>
    {
        public string Value { get; internal set; }

        protected City() { }

        public static City FromString(string Value)
        {
            if (Value.IsEmpty())
                throw new ArgumentNullException(nameof(Value));

            return new City(Value);
        }

        internal City(string value) => Value = value;

        public static implicit operator string(City city) => city.Value;

        public static City NoDelivery => new City();

        
    }
}
