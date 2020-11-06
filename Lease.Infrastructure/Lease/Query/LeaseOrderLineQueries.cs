using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Lease.Infrastructure.Lease.ReadModels;

namespace Lease.Infrastructure.Lease.Query
{
    public static class LeaseOrderLineQueries
    {
        public static Task<LeaseOrderLineDetails> GetAllLeaseOrderLine(this DbContext connection)
        {
            return connection.Query<Domain.LeaseOrderLine>().AsNoTracking()
                .Select(x => new LeaseOrderLineDetails
                {
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsReturned = x.IsReturned,
                    RessourceName = x.RessourceName,
                    RessourcePrice = x.RessourcePrice,
                    Quantity = x.Quantity,
                    LineTotalPrice = x.LineTotalPrice
                })
                .FirstOrDefaultAsync();
        }

        public static Task<LeaseOrderLineDetails> GetLeaseOrderLineById(this DbContext connection, QueryModels.GetLeaseOrderLineById query)
        {
            return connection.Query<Domain.LeaseOrderLine>().AsNoTracking()
                .Where(x => x.leaseOrderLineId == query.LeaseOrderLineId)
                .Select(x => new LeaseOrderLineDetails
                {
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsReturned = x.IsReturned,
                    RessourceName = x.RessourceName,
                    RessourcePrice = x.RessourcePrice,
                    Quantity = x.Quantity,
                    LineTotalPrice = x.LineTotalPrice

                })
                .FirstOrDefaultAsync();
        }
    }
}
