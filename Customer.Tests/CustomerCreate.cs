using Customer.Domain.Customer;
using Customer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Customer.Tests
{
    public class CustomerCreate
    {
        private readonly Customer.Domain.Customer.Customer _customer;

        public CustomerCreate()
        {
            _customer = new Domain.Customer.Customer(
             new CustomerId(Guid.NewGuid()),
            FullName.FromString("ST Skolebyg"),
            Adresse.FromString("Vardevej 98", 7100, "Vejle"),
            PhoneNo.FromInt(22222222),
            Email.FromString("Skolebyg@st.dk"),
            CustomerType.FromString(1.ToString())

            );
        }

        
        

        //Cannot update tests
        [Fact]
        public void Cannot_update_with_wrong_Email()
        {
            Assert.Throws<System.ArgumentNullException>(() => _customer.UpdateEmail(Email.FromString("Skole.dk")));
        }

        [Fact]
        public void Cannot_update_with_empty_Email()
        {
            Assert.Throws<System.ArgumentNullException>(() => _customer.UpdateEmail(Email.FromString("")));
        }

        [Fact]
        public void Cannot_update_with_wrong_PhoneNo()
        {
            Assert.Throws<System.ArgumentNullException>(() => _customer.UpdatePhoneNo(PhoneNo.FromInt(0)));
        }

        [Fact]
        public void Cannot_update_with_empty_Adresse_Street()
        {
            Assert.Throws<System.ArgumentNullException>(() => _customer.UpdateAdresse(Adresse.FromString("", 7100, "Vejle")));
        }

        [Fact]
        public void Cannot_update_with_empty_Adresse_City()
        {
            Assert.Throws<System.ArgumentNullException>(() => _customer.UpdateAdresse(Adresse.FromString("Testvej 9", 7100, "")));
        }

        [Fact]
        public void Cannot_update_with_empty_Adresse_ZipCode()
        {
            Assert.Throws<System.ArgumentNullException>(() => _customer.UpdateAdresse(Adresse.FromString("Testvej 9", 0, "Vejle")));
        }

        [Fact]
        public void Cannot_update_with_empty_Name()
        {
            Assert.Throws<System.ArgumentNullException>(() => _customer.UpdateName(FullName.FromString("")));
        }
    }
}
