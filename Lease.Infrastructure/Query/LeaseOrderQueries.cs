using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Lease.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using static Delpin.Shared.LeaseModels.LeaseReadModelsDto;

namespace Lease.Intrastructure.Query
{
    public class LeaseOrderQueries
    {
        private readonly LeaseDbContext _context;

        public LeaseOrderQueries(LeaseDbContext leaseDbContext)
        {
            _context = leaseDbContext;
        }

        public async Task<List<LeaseOrderDetails>> GetAllLease()
        {
            return await _context.Leases.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new LeaseOrderDetails
                {
                    Street = x.Street.Value,
                    City = x.City.Value,
                    DateCreated = x.DateCreated.Value,
                    IsDeleted = x.IsDeleted.Value,
                    IsDelivery = x.IsDelivery.Value,
                    IsPaid = x.IsPaid.Value,
                    LeaseId = x.LeaseOrderId,
                    BuyerId = x.Buyer.BuyerId,
                    BuyerName = x.Buyer.BuyerName.Value,
                    TotalPrice = x.TotalPrice.Value,
                    ZipCode = x.ZipCode.Value,
                    
                    leaseOrderLines = x.LeaseOrderLines.Select(x => new LeaseOrderLineDetails
                    {
                        LeaseOrderLineId = x.LeaseOrderLineId,
                        StartDate = x.StartDate.Value,
                        EndDate = x.EndDate.Value,
                        IsReturned = x.IsReturned.Value,
                        LineTotalPrice = x.LineTotalPrice.Value,
                        Quantity = x.Quantity.Value,
                        ResourceName = x.ResourceName.Value,
                        ResourcePrice = x.ResourcePrice.Value,
                        ResourceId = x.ResourceId.Value
                    })
                    .ToList()
                })
                 .OrderByDescending(x => x.DateCreated)
                 .ToListAsync();
        }

 
        public async Task<LeaseOrderDetails> GetLeaseById(QueryModels.GetLeaseOrderById query)
        {
            return await _context.Leases.AsNoTracking()
                .Where(x => x.LeaseOrderId == query.LeaseId && x.IsDeleted.Value == false)   
                .Select(x => new LeaseOrderDetails 
                {
                    Street = x.Street.Value,
                    City = x.City.Value,
                    DateCreated = x.DateCreated.Value,
                    IsDeleted = x.IsDeleted.Value,
                    IsDelivery = x.IsDelivery.Value,
                    IsPaid = x.IsPaid.Value,
                    LeaseId = x.LeaseOrderId,
                    BuyerId = x.Buyer.BuyerId,
                    BuyerName = x.Buyer.BuyerName.Value,
                    TotalPrice = x.TotalPrice.Value,
                    ZipCode = x.ZipCode.Value,

                    leaseOrderLines = x.LeaseOrderLines.Select(x => new LeaseOrderLineDetails
                    {
                        LeaseOrderLineId = x.LeaseOrderLineId,
                        StartDate = x.StartDate.Value,
                        EndDate = x.EndDate.Value,
                        IsReturned = x.IsReturned.Value,
                        LineTotalPrice = x.LineTotalPrice.Value,
                        Quantity = x.Quantity.Value,
                        ResourceName = x.ResourceName.Value,
                        ResourcePrice = x.ResourcePrice.Value,
                        ResourceId = x.ResourceId.Value
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<LeaseOrderDetails>> GetLeaseByBuyerId(QueryModels.GetLeasesByBuyerId query)
        {
            return await _context.Leases.AsNoTracking()
                .Where(x => x.Buyer.BuyerId == query.BuyerId && x.IsDeleted.Value == false)
                .Select(x => new LeaseOrderDetails
                {
                    Street = x.Street.Value,
                    City = x.City.Value,
                    DateCreated = x.DateCreated.Value,
                    IsDeleted = x.IsDeleted.Value,
                    IsDelivery = x.IsDelivery.Value,
                    IsPaid = x.IsPaid.Value,
                    LeaseId = x.LeaseOrderId,
                    BuyerId = x.Buyer.BuyerId,
                    BuyerName = x.Buyer.BuyerName.Value,
                    TotalPrice = x.TotalPrice.Value,
                    ZipCode = x.ZipCode.Value,

                    leaseOrderLines = x.LeaseOrderLines.Select(x => new LeaseOrderLineDetails
                    {
                        LeaseOrderLineId = x.LeaseOrderLineId,
                        StartDate = x.StartDate.Value,
                        EndDate = x.EndDate.Value,
                        IsReturned = x.IsReturned.Value,
                        LineTotalPrice = x.LineTotalPrice.Value,
                        Quantity = x.Quantity.Value,
                        ResourceName = x.ResourceName.Value,
                        ResourcePrice = x.ResourcePrice.Value,
                        ResourceId = x.ResourceId.Value,
                        
                    })
                    .ToList()
                })
                 .OrderByDescending(x => x.DateCreated)
                .ToListAsync();
        }

     
        public async Task<List<LeaseOrderListItem>> GetSearchedLeases(QueryModels.GetSearchedLeases query)
        {
            return await _context.Leases.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false && (x.LeaseOrderId.ToString() == query.SearchTerm 
                ||x.City.Value.Contains(query.SearchTerm) || x.ZipCode.Value.ToString().Contains(query.SearchTerm) || x.Buyer.BuyerName.Value.Contains(query.SearchTerm)))
                .Select(x => new LeaseOrderListItem
                {
                    DateCreated = x.DateCreated.Value,
                    IsPaid = x.IsPaid.Value,
                    LeaseId = x.LeaseOrderId,
                    BuyerName = x.Buyer.BuyerName.Value
                })
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync();
        }

        public async Task<List<EditLeaseOrderLineDetails>> GetLeaseOrderLineIdById(QueryModels.GetLeaseOrderLineById query)
        {
            return await _context.LeaseOrderLines.AsNoTracking()
                .Where(x => x.LeaseOrderLineId == query.LeaseOrderLineId)
                .Select(x => new EditLeaseOrderLineDetails
                {
                    LeaseOrderLineId = x.LeaseOrderLineId,
                    StartDate = x.StartDate.Value,
                    EndDate = x.EndDate.Value,
                    IsReturned = x.IsReturned.Value,
                    LineTotalPrice = x.LineTotalPrice.Value,
                    Quantity = x.Quantity.Value,
                    ResourceName = x.ResourceName.Value,
                    ResourcePrice = x.ResourcePrice.Value, 
                })
                 .OrderByDescending(x => x.StartDate)
                .ToListAsync();
        }
    }
}