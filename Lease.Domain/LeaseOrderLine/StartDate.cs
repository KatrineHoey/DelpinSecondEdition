using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lease.Domain
{
    public class StartDate : Value<StartDate>
    {
        public DateTime Value { get; internal set; }

        protected StartDate() { }

        public StartDate(DateTime startDate) => Value = startDate;

        public static StartDate FromDateTime(DateTime startDate)
        {
            CheckValidity(startDate.ToString());
            return new StartDate(startDate);
        }

        public static implicit operator DateTime(StartDate startDate) =>
            startDate.Value;

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
