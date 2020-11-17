using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Lease.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using static Lease.Intrastructure.Query.ReadModels;

namespace Lease.Intrastructure.Query
{
    public class LeaseOrderQueries
    {
        private readonly LeaseDbContext _context;

        public LeaseOrderQueries(LeaseDbContext leaseDbContext)
        {
            _context = leaseDbContext;
        }

        public async  Task<List<LeaseOrderDetails>> GetAllLease()
        {
            return await _context.Leases.AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Select(x => new LeaseOrderDetails
                {
                    Street = x.Street,
                    City = x.City,
                    DateCreated = x.DateCreated,
                    IsDeleted = x.IsDeleted,
                    IsDelivery = x.IsDelivery,
                    IsPaid = x.IsPaid,
                    LeaseId = x.LeaseOrderId,
                    BuyerId = x.Buyer.BuyerId,
                    BuyerName = x.Buyer.BuyerName,
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
                        RessourcePrice = x.RessourcePrice,
                        RessourceId = x.RessourceId
                    })
                    .ToList()
                })
                 .OrderByDescending(x => x.DateCreated)
                 .ToListAsync();
        }

 
        public async Task<LeaseOrderDetails> GetLeaseById(QueryModels.GetLeaseOrderById query)
        {
            return await _context.Leases.AsNoTracking()
                .Where(x => x.LeaseOrderId == query.LeaseId && x.IsDeleted == false)   
                .Select(x => new LeaseOrderDetails 
                { 
                    Street = x.Street,
                    City = x.City,
                    DateCreated = x.DateCreated,
                    IsDeleted = x.IsDeleted,
                    IsDelivery = x.IsDelivery,
                    IsPaid = x.IsPaid,
                    BuyerId = x.Buyer.BuyerId,
                    BuyerName = x.Buyer.BuyerName,
                    LeaseId = x.LeaseOrderId,
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
                        RessourcePrice = x.RessourcePrice,
                        RessourceId = x.RessourceId
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<LeaseOrderDetails>> GetLeaseByBuyerId(QueryModels.GetLeasesByBuyerId query)
        {
            return await _context.Leases.AsNoTracking()
                .Where(x => x.Buyer.BuyerId == query.BuyerId && x.IsDeleted == false)
                .Select(x => new LeaseOrderDetails
                {
                    Street = x.Street,
                    City = x.City,
                    DateCreated = x.DateCreated,
                    IsDeleted = x.IsDeleted,
                    IsDelivery = x.IsDelivery,
                    IsPaid = x.IsPaid,
                    BuyerId = x.Buyer.BuyerId,
                    BuyerName = x.Buyer.BuyerName.Value,
                    LeaseId = x.LeaseOrderId,
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
                        RessourcePrice = x.RessourcePrice,
                        RessourceId = x.RessourceId
                    })
                    .ToList()
                })
                 .OrderByDescending(x => x.DateCreated)
                .ToListAsync();
        }

     
        public async Task<List<LeaseOrderListItem>> GetSearchedLeases(QueryModels.GetSearchedLeases query)
        {
            return await _context.Leases.AsNoTracking()
                .Where(x => x.IsDeleted == false && (x.LeaseOrderId.ToString() == query.SearchTerm 
                ||x.City.Contains(query.SearchTerm) || x.ZipCode.ToString().Contains(query.SearchTerm)))
                .Select(x => new LeaseOrderListItem
                {
                    DateCreated = x.DateCreated,
                    IsPaid = x.IsPaid,
                    LeaseId = x.LeaseOrderId
                })
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync();
        }

    }
}