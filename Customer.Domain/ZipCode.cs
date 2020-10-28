using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain
{
    public class ZipCode : Value<ZipCode>
    {
        internal ZipCode(int number)
        {
            if (number > 9999 || number < 0555)
                throw new ArgumentNullException(
                    nameof(number), "Zipcode most be valid.");

            Value = number;
        }

        // Satisfy the serialization requirements 
        protected ZipCode()
        {
        }

        public int Value { get; }

        public static ZipCode FromString(string text)
        {
            return new ZipCode(Convert.ToInt32(text));
        }

        public static implicit operator string(ZipCode number)
        {
            return number.Value.ToString();
        }
    }
}
