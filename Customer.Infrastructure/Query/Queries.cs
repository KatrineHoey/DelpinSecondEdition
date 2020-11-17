using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Customer.Infrastructure.Query.QueryModels;
using static Delpin.Shared.CustomerModels.ReadModels;

namespace Customer.Infrastructure.Query
{
    public static class Queries
    {

        public static Task<CustomerDetails> Query(this IAsyncDocumentSession session, GetCustomerById query)
        {

             return session.Query<Domain.Customer.Customer>()
                .Where(x => x.Id.Value == query.CustomerId)
                .Select(
                    x => new CustomerDetails
                    {
                        CustomerId = x.Id.Value,
                        FullName = x.FullName.Value,
                        PhoneNo = x.PhoneNo.Value,
                        Email = x.Email.Value,
                        CustomerType = (Delpin.Shared.CustomerModels.CustomerTypeEnum)x.CustomerType.Value,
                        Street = x.Adresse.Street.Value,
                        City = x.Adresse.City.Value,
                        ZipCode = x.Adresse.ZipCode.Value,
                        IsDeleted = x.IsDeleted.Value
                    }).FirstOrDefaultAsync();
        }

        public static Task<List<ActiveCustomerSearchListItem>> Query(this IAsyncDocumentSession session, GetSearchedActiveCustomers query)
        {
            return session.Query<Domain.Customer.Customer>()
                .Search(x => x.FullName, query.SearchTerm)
                .Search(x => x.PhoneNo, query.SearchTerm)
                .Where(x => x.IsDeleted.Value == false)
                .Select(
                    x => new ActiveCustomerSearchListItem
                    {
                        CustomerId = x.Id.Value,
                        FullName = x.FullName.Value,
                        PhoneNo = x.PhoneNo.Value,
                        City = x.Adresse.City.Value
                    }).PagedList(query.Page, query.PageSize);
        }

        private static Task<List<T>> PagedList<T>(this IRavenQueryable<T> query, int page, int pageSize)
        {
            return query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
