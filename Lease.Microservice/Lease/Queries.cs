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
        public static Task<LeaseOrderDetails> GetAllLease(this DbContext connection)
        {
            return connection.Query<Domain.Lease>().AsNoTracking()
                .Select(x => new LeaseOrderDetails
                {
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

        public static Task<LeaseOrderDetails> GetLeaseById(this DbContext connection, QueryModels.GetLeaseOrderById query)
        {
            return connection.Query<Domain.Lease>().AsNoTracking()
                .Where(x => x.leaseId == query.LeaseId)
                .Select(x => new LeaseOrderDetails 
                { 
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