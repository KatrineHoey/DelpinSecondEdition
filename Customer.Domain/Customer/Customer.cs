using Customer.Domain.Shared;
using Delpin.Framework;
using System;
using System.ComponentModel;

namespace Customer.Domain.Customer
{
    public class Customer : AggregateRoot<CustomerId>
    {
        public Customer(CustomerId id, FullName fullName, Adresse adresse, PhoneNo phoneNo, Email email, CustomerType customerType)
        {
            Apply(new Events.CustomerRegistered
            {
                CustomerId = id,
                FullName = fullName,
                PhoneNo = phoneNo,
                Email = email,
                CustomerType = customerType,
                Street = adresse.Street,
                ZipCode = adresse.ZipCode,
                City = adresse.City
                
            });
        }

        // Satisfy the serialization requirements
        protected Customer()
        {
        }

        // Properties to handle the persistence
        private string DbId
        {
            get => $"Customer/{Id.Value}";
            set { }
        }

        // Aggregate state properties
        public FullName FullName { get; private set; }
        public Adresse Adresse { get; private set; }
        public PhoneNo PhoneNo { get; private set; }
        public Email Email { get; private set; }
        public CustomerType CustomerType { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        public void UpdateName(FullName fullname)
        {
            Apply(new Events.CustomerFullNameUpdated
            {
                CustomerId = Id,
                FullName = fullname
            }) ;
        }

        public void UpdateAdresse(Adresse adresse)
        {
            Apply(new Events.CustomerAdresseUpdated
            {
                CustomerId = Id,
                City = adresse.City,
                Street = adresse.Street,
                ZipCode = adresse.ZipCode
            });
        }

        public void UpdateEmail(Email email)
        {
            Apply(new Events.CustomerEmailUpdated
            {
                CustomerId = Id,
                Email = email
            });
        }

        public void UpdatePhoneNo(PhoneNo phoneNo)
        {
            Apply(new Events.CustomerPhoneNoUpdated
            {
                CustomerId = Id,
                PhoneNo = phoneNo
            });
        }

        public void ChangeCustomerType(CustomerType customertype)
        {
            Apply(new Events.CustomerTypeChanged
            {
                CustomerId = Id,
                CustomerType = customertype
            });
        }

        public void ChangeCustomerType(IsDeleted isDeleted)
        {
            Apply(new Events.CustomerDeleted
            {
                CustomerId = Id,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {

            switch (@event)
            {
                case Events.CustomerRegistered e:
                    Id = new CustomerId(e.CustomerId);
                    FullName = new FullName(e.FullName);
                    PhoneNo = new PhoneNo(e.PhoneNo);
                    Email = new Email(e.Email);
                    CustomerType = new CustomerType(e.CustomerType);
                    break;
                case Events.CustomerTypeChanged e:
                    CustomerType = new CustomerType(e.CustomerType);
                    break;
                case Events.CustomerAdresseUpdated e:
                    Adresse = new Adresse(new Street(e.Street), new ZipCode(e.ZipCode), new City(e.City));
                    break;
                case Events.CustomerFullNameUpdated e:
                    FullName = new FullName(e.FullName);
                    break;
                case Events.CustomerEmailUpdated e:
                    Email = new Email(e.Email);
                    break;
                case Events.CustomerPhoneNoUpdated e:
                    PhoneNo = new PhoneNo(e.PhoneNo);
                    break;
                case Events.CustomerDeleted e:
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = Id != null;

            if (!valid)
                throw new DomainExceptions.InvalidEntityState(this,
                    $"Post-checks failed.");
        }
    }
}
