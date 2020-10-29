using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain
{
    public class Email : Value<Email>
    {
        internal Email(string email)
        {
            if(!email.Contains('@') || !email.Contains('.'))
                throw new ArgumentNullException(
               nameof(email), "Email most be valid.");

            Value = email;
        }

        // Satisfy the serialization requirements 
        protected Email()
        {
        }

        public string Value { get; }

        public static Email FromString(string email)
        {

            if (email.IsEmpty())
                throw new ArgumentNullException(nameof(email));

            return new Email(email);
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }
    }
}
