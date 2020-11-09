using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Lease.Domain;
using Microsoft.EntityFrameworkCore;
using static Lease.Infrastructure.Lease.ReadModels;


namespace Lease.Infrastructure.Lease
{
    public static class LeaseOrderQueries
    {
        [System.Obsolete]
        public async static Task<List<LeaseOrderDetails>> GetAllLease(DbContext connection)
        {
            return connection.Query<LeaseOrder>().AsNoTracking()
                .AsEnumerable()
                .Where(x => x.IsDeleted == false)
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
                    ZipCode = x.ZipCode,
                })
                 .OrderByDescending(x => x.DateCreated)
                 .ToList();
        }

        [System.Obsolete]
        public async static Task<LeaseOrderDetails> GetLeaseById(this DbContext connection, QueryModels.GetLeaseOrderById query)
        {
            return connection.Query<Domain.LeaseOrder>().AsNoTracking()
                .AsEnumerable()
                .Where(x => x.leaseId == query.LeaseId && x.IsDeleted == false)   
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
                    ZipCode = x.ZipCode,
                    leaseOrderLines = x.LeaseOrderLines.Select(x => new LeaseOrderLineDetails {
                        LeaseOrderLineId = x.LeaseOrderLineId,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        IsReturned = x.IsReturned,
                        LineTotalPrice = x.LineTotalPrice,
                        Quantity = x.Quantity,
                        RessourceName = x.RessourceName,
                        RessourcePrice = x.RessourcePrice})
                    .ToList()
                })
                .FirstOrDefault();
        }

        [System.Obsolete]
        public async static Task<List<LeaseOrderDetails>> GetLeaseByCustomerId(this DbContext connection, QueryModels.GetLeasesByCustomerId query)
        {
            return connection.Query<Domain.LeaseOrder>().AsNoTracking()
                .AsEnumerable()
                .Where(x => x.CustomerId == query.CustomerId && x.IsDeleted == false)
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
                    ZipCode = x.ZipCode,
                    leaseOrderLines = x.LeaseOrderLines.Select(x => new LeaseOrderLineDetails
                    {
                        LeaseOrderLineId = x.LeaseOrderLineId,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        IsReturned = x.IsReturned,
                        LineTotalPrice = x.LineTotalPrice,
                        Quantity = x.Quantity,
                        RessourceName = x.RessourceName,
                        RessourcePrice = x.RessourcePrice
                    })
                    .ToList()
                })
                 .OrderByDescending(x => x.DateCreated)
                .ToList();
        }

        [System.Obsolete]
        public async static Task<List<LeaseOrderListItem>> GetSearchedLeases(this DbContext connection, QueryModels.GetSearchedLeases query)
        {
            return connection.Query<Domain.LeaseOrder>().AsNoTracking()
                .AsEnumerable()
                .Where(x => x.Id.ToString().Contains(query.SearchTerm))
                .Where(x => x.CustomerId.ToString().Contains(query.SearchTerm))
                .Where(x => x.City.ToString().Contains(query.SearchTerm))
                .Where(x => x.ZipCode.ToString().Contains(query.SearchTerm))
                .Where(x => x.IsDeleted == false)
                .Select(x => new LeaseOrderListItem
                {
                    DateCreated = x.DateCreated,
                    IsPaid = x.IsPaid,
                    LeaseId = x.leaseId
                })
                .OrderByDescending(x => x.DateCreated)
                .ToList();
        }

    }
}