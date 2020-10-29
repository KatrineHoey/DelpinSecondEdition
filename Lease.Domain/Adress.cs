using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class Adresse : Value<Adresse>
    {
        public Street Street { get; set; }

        public ZipCode ZipCode { get; set; }

        public City City { get; set; }

        public Adresse(Street street, ZipCode zipCode, City city)
        {
            Street = street;
            ZipCode = zipCode;
            City = city;
        }

        // Satisfy the serialization requirements 
        protected Adresse()
        {
        }

        public static Adresse FromString(Street street,ZipCode zipCode,City city)
        {
            return new Adresse(street,zipCode,city);
        }
    }
}

