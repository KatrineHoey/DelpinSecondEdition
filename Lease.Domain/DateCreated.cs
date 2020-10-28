using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lease.Domain
{
    public class DateCreated : Value<DateCreated>
    {
        public DateTime Value { get; internal set; }

        protected DateCreated() { }

        internal DateCreated(DateTime dateCreated) => Value = dateCreated;

        public static DateCreated FromDateTime(DateTime dateCreated) 
        {
            CheckValidity(dateCreated);
            return new DateCreated(dateCreated);
        }
        
        public static implicit operator DateTime(DateCreated dateCreated) =>
            dateCreated.Value;

        public static DateCreated NoDate => new DateCreated();

        private static void CheckValidity(DateTime value)
        {
            string[] formats = { "MM/dd/yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy" };

            DateTime expectedDate;

            if (!DateTime.TryParseExact("07/27/2012", formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                throw new ArgumentOutOfRangeException("DateTime is in another format", nameof(value));
            }
        }
    }
}
