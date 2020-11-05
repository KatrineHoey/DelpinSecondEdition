using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lease.Domain
{
    public class EndDate : Value<EndDate>
    {
        public DateTime Value { get; internal set; }

        protected EndDate() { }

        public EndDate(DateTime endDate) => Value = endDate;

        public static EndDate FromDateTime(DateTime endDate)
        {
            CheckValidity(endDate.ToString());
            return new EndDate(endDate);
        }

        public static implicit operator DateTime(EndDate endDate) =>
            endDate.Value;

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
