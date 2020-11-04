using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using static Lease.Microservice.Lease.ReadModels;

namespace Lease.Microservice.Lease
{
    public static class Queries
    {
        public static Task<LeaseDetails> Query(this DbContext connection, QueryModels.GetLeaseById query)
        {
            return connection.Query<Domain.Lease>().AsNoTracking()
                .Where(x => x.leaseId == query.LeaseId)
                .Select(x => new LeaseDetails { 
                    Street = x.Street,
                City = x.City,
                DateCreated = x.DateCreated,
                IsDeleted = x.IsDeleted,
                IsDelivery = x.IsDelivery,
                IsPaid = x.IsPaid,
                LeaseId = x.leaseId,
                TotalPrice = x.TotalPrice,
                ZipCode = x.ZipCode
                })
                .FirstOrDefaultAsync();
        }  
    }
}