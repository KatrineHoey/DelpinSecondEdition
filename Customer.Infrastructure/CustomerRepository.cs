using Customer.Domain.Customer;
using Raven.Client.Documents.Session;
using Customer.Infrastructure.Shared;
using Customer.Application.Command;

namespace Customer.Infrastructure
{
    public class CustomerRepository : RavenDbRepository<Domain.Customer.Customer, CustomerId>, ICustomerRepository
    {
        public CustomerRepository(IAsyncDocumentSession session)
            : base(session, id => $"Customer/{id.Value.ToString()}")
        {
        }
    }
}
