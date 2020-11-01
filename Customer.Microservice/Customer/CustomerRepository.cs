using Customer.Domain.Customer;
using Raven.Client.Documents.Session;
using Customer.Microservice.Infrastructure;

namespace Customer.Microservice.Customer
{
    public class CustomerRepository : RavenDbRepository<Domain.Customer.Customer, CustomerId>, ICustomerRepository
    {
        public CustomerRepository(IAsyncDocumentSession session)
            : base(session, id => $"Customer/{id.Value.ToString()}")
        {
        }
    }
}
