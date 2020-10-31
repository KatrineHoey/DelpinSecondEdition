using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Customer
{
    public interface ICustomerRepository
    {
        Task<Customer> Load(CustomerId id);

        Task Add(Customer entity);

        Task<bool> Exists(CustomerId id);
    }
}
