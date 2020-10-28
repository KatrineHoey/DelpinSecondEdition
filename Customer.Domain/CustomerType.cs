using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain
{
    public class CustomerType : Value<CustomerType>
    {
        public enum CustomerTypeEnum
        {
            Erhverv = 1,
            Privat = 2
        }

        internal CustomerType(CustomerTypeEnum type)
        {
            Value = type;
        }

        public CustomerTypeEnum Value { get; internal set; } = CustomerTypeEnum.Privat;

        // Satisfy the serialization requirements 
        protected CustomerType() { }

        public static CustomerType FromString(string type)
        {
            CustomerTypeEnum customerType = (CustomerTypeEnum)Enum.Parse(typeof(CustomerTypeEnum), type, true);
            return new CustomerType(customerType);
        }

        public static implicit operator CustomerTypeEnum(CustomerType type)
        {
            return type.Value;
        }

    }


}
