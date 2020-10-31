using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Customer
{
    public class ZipCode : Value<ZipCode>
    {
        internal ZipCode(int zipcode)
        {
            if (zipcode > 9999 || zipcode < 0555)
                throw new ArgumentNullException(
                    nameof(zipcode), "ZipCode most be valid.");

            Value = zipcode;
        } 

        // Satisfy the serialization requirements 
        protected ZipCode()
        {
        }

        public int Value { get; }

        public static ZipCode FromString(string zipcode)
        {

            if (zipcode.IsEmpty())
                throw new ArgumentNullException(nameof(zipcode));

            return new ZipCode(Convert.ToInt32(zipcode));
        }

        public static implicit operator int(ZipCode zipcode)
        {
            return zipcode.Value;
        }
    }
}
