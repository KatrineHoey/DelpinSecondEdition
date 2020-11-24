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

        public int Value { get; internal set; }

        public static ZipCode FromInt(int zipcode)
        {

            if (zipcode == 0)
                throw new ArgumentNullException(nameof(zipcode));

            return new ZipCode(zipcode);
        }

        public static implicit operator int(ZipCode zipcode)
        {
            return zipcode.Value;
        }
    }
}
