using Customer.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Command
{
    public interface ICustomerRepository
    {
        Task<Domain.Customer.Customer> Load(CustomerId id);

        Task Add(Domain.Customer.Customer entity);

        Task<bool> Exists(CustomerId id);
    }
}
