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

        public DateCreated(DateTime dateCreated) => Value = dateCreated;

        public static DateCreated FromDateTime(DateTime dateCreated) 
        {
            CheckValidity(dateCreated.ToString());
            return new DateCreated(dateCreated);
        }
        
        public static implicit operator DateTime(DateCreated dateCreated) =>
            dateCreated.Value;

        public static DateCreated NoDate => new DateCreated();

        private static bool CheckValidity(string dateFormat)
        {
            try
            {
                string dts = DateTime.Now.ToString(dateFormat, CultureInfo.InvariantCulture);
                DateTime.ParseExact(dts, dateFormat, CultureInfo.InvariantCulture);
                return true;
                
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("DateTime is in another format", nameof(dateFormat));
            }
        }
    }
}
