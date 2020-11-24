﻿using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Customer
{
    public class PhoneNo : Value<PhoneNo>
    {
        internal PhoneNo(int phoneNo)
        {
            if (phoneNo <= 0)
                throw new ArgumentNullException(
                    nameof(phoneNo), "PhoneNo most be valid.");

            Value = phoneNo;
        }

        // Satisfy the serialization requirements 
        protected PhoneNo()
        {
        }

        public int Value { get; internal set; }

        public static PhoneNo FromInt(int phoneNo)
        {

            if (phoneNo == 0)
                throw new ArgumentNullException(nameof(phoneNo));

            return new PhoneNo(phoneNo);
        }

        public static implicit operator int(PhoneNo phoneNo)
        {
            return phoneNo.Value;
        }
    }
}
