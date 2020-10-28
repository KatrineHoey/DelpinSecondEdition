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

        internal Adresse(Street street, ZipCode zipCode, City city)
        {
            Street = street;
            ZipCode = zipCode;
            City = city;
        }

    }
}

