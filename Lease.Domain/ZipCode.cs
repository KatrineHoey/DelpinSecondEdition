using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lease.Domain
{
    public class ZipCode : Value<ZipCode>
    {
        public int Value { get; }

        public ZipCode(int number)
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

        public static ZipCode FromInt(int text)
        {
            return new ZipCode(Convert.ToInt32(text));
        }

        public static implicit operator int(ZipCode number)
        {
            return number.Value;
        }
    }
}
