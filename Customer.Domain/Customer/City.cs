using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Customer
{
    public class City : Value<City>
    {
        internal City(string city)
        {
            Value = city;
        }

        // Satisfy the serialization requirements 
        protected City()
        {
        }

        public string Value { get; internal set; }

        public static City FromString(string city)
        {
            if (city.IsEmpty())
                throw new ArgumentNullException(nameof(city));

            return new City(city);
        }

        public static implicit operator string(City city)
        {
            return city.Value;
        }
    }
}
