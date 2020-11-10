using System;
using System.Threading.Tasks;
using Delpin.Framework;
using Lease.Domain.Shared;
using Lease.Domain;
using Lease.Domain.InterFace;
using static Lease.Infrastructure.Lease.LeaseOrderCommands;

namespace Lease.Infrastructure.Lease
{
    public class LeaseApplicationService : IApplicationService
    {
        private readonly ILeaseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        
        public LeaseApplicationService(ILeaseRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateLease cmd => HandleCreate(cmd),

                V1.UpdateAddress cmd => HandleUpdate(cmd.LeaseId,
                        c => c.LeaseAddressUpdated(Street.FromString(cmd.Street), ZipCode.FromInt(cmd.ZipCode), City.FromString(cmd.City))),

                V1.DeleteLease cmd => HandleUpdate(cmd.LeaseId,
                        c => c.LeaseDeleted(IsDeleted.FromBool(cmd.IsDeleted))),

                V1.UpdateIsDelivery cmd => HandleUpdate(cmd.LeaseId,
                        c => c.IsDeliveryUpdated(IsDelivery.FromBool(cmd.IsDelivery))),

                V1.UpdateIsPaid cmd => HandleUpdate(cmd.LeaseId,
                        c => c.IsPaidUpdated(IsPaid.FromString(cmd.IsPaid.ToString()))),

                V1.UpdateTotalPrice cmd => HandleUpdate(cmd.LeaseId,
                        c => c.TotalPriceUpdated(TotalPrice.FromDecimal(cmd.TotalPrice))),

                //LeaseOrderLine
                V1.AddLeaseOrderLineToLeaseOrder cmd => HandleCreateLeaseOrderLine(cmd),

                V1.DeleteLeaseOrderLine cmd => HandleDeleteLeaseOrderLine(cmd.LeaseId),

                V1.UpdateLeaseOrderLine cmd => HandleUpdateLeaseOrderLine(cmd.LeaseOrderLineId,
                      c => c.UpdateLeaseOrderLine(StartDate.FromDateTime(cmd.StartDate), EndDate.FromDateTime(cmd.EndDate), IsReturned.FromBool(cmd.IsReturned), RessourceName.FromString( cmd.RessourceName), RessourcePrice.FromInt(cmd.RessourcePrice), Quantity.FromInt(cmd.Quantity))),

                _ => Task.CompletedTask
            };
      
        private async Task HandleCreate(V1.CreateLease cmd)
        {
            if (await _repository.LeaseOrderExists(cmd.LeaseId))
                throw new InvalidOperationException($"Entity with id {cmd.LeaseId} already exists");

            var lease = new LeaseOrder(
                    cmd.LeaseId,
                    cmd.CustomerId,
                    DateTime.UtcNow,
                    cmd.IsDelivery,
                    cmd.IsPaid,
                    cmd.Street,
                    cmd.ZipCode,
                    cmd.City

                );

            await _repository.AddLeaseOrder(lease);
            await _unitOfWork.Commit();
        }

        private async Task HandleCreateLeaseOrderLine(V1.AddLeaseOrderLineToLeaseOrder cmd)
        {
            if (await _repository.LeaseOrderLineExists(cmd.LeaseOrderLineId))
                throw new InvalidOperationException($"Entity with id {cmd.LeaseOrderLineId} already exists");

            var leaseOrderLine = new LeaseOrderLine(
                    cmd.LeaseOrderLineId,
                    cmd.LeaseId,
                    cmd.StartDate,
                    cmd.EndDate,
                    cmd.IsReturned,
                    cmd.RessourceName,
                    cmd.RessourcePrice,
                    cmd.Quantity

                );

            await _repository.AddLeaseOrderLine(leaseOrderLine);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid leaseId,Action<LeaseOrder> operation)
        {
            var lease = await _repository.LoadLeaseOrder(leaseId);

            if (lease == null)
                throw new InvalidOperationException($"Entity with id {leaseId} cannot be found");

            operation(lease);

            await _unitOfWork.Commit();
        }

        private async Task HandleUpdateLeaseOrderLine(Guid leaseorderLineId, Action<LeaseOrderLine> operation)
        {
            var lease = await _repository.LoadLeaseOrderLine(leaseorderLineId);

            if (lease == null)
                throw new InvalidOperationException($"Entity with id {leaseorderLineId} cannot be found");

            operation(lease);

            await _unitOfWork.Commit();
        }

        private async Task HandleDeleteLeaseOrderLine(Guid id)
        {
            var entity = await _repository.LoadLeaseOrderLine(id);

            if (entity == null)
                throw new InvalidOperationException($"Entity with id {id} cannot be found");

            await _repository.DeleteLeaseOrderLine(id);

            await _unitOfWork.Commit();
        }
    }
}