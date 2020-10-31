using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Customer
{
    public class Adresse : Value<Adresse>
    {
        public Street Street { get; set; }
        public ZipCode ZipCode { get; set; }
        public City City { get; set; }

        public Adresse(Street street, ZipCode zipcode, City city)
        {
            Street = street;
            ZipCode = zipcode;
            City = city;
        }

        // Satisfy the serialization requirements 
        protected Adresse()
        {
        }


    }
}
