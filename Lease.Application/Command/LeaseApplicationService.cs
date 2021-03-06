using System;
using System.Threading.Tasks;
using Delpin.Framework;
using Lease.Application;
using Lease.Domain;
using Delpin.Shared.LeaseModels;
using static Delpin.Shared.LeaseModels.LeaseOrderCommands;

namespace Lease.Application
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
                        c => c.IsPaidUpdated(IsPaid.FromBool(cmd.IsPaid))),

                V1.UpdateTotalPrice cmd => HandleUpdate(cmd.LeaseId,
                        c => c.TotalPriceUpdated(TotalPrice.FromInt(cmd.TotalPrice))),

                //LeaseOrderLine
                LeaseOrderLineCommands.V1.AddLeaseOrderLineToLeaseOrder cmd => HandleCreateLeaseOrderLine(cmd),

                LeaseOrderLineCommands.V1.DeleteLeaseOrderLine cmd => HandleDeleteLeaseOrderLine(cmd.LeaseId),

                LeaseOrderLineCommands.V1.UpdateLeaseOrderLine cmd => HandleUpdateLeaseOrderLine(cmd.LeaseOrderLineId,
                      c => c.UpdateLeaseOrderLine(StartDate.FromDateTime(cmd.StartDate), EndDate.FromDateTime(cmd.EndDate), IsReturned.FromBool(cmd.IsReturned), ResourceName.FromString( cmd.ResourceName), ResourcePrice.FromInt(cmd.ResourcePrice), Quantity.FromInt(cmd.Quantity))),

                //Buyer
                BuyerCommands.V1.CreateBuyer cmd => HandleCreateBuyer(cmd),

                BuyerCommands.V1.DeleteBuyer cmd => HandleDeleteBuyer(cmd.BuyerId),

                BuyerCommands.V1.UpdateBuyer cmd => HandleUpdateBuyer(cmd.BuyerId,
                    c => c.UpdateBuyer(BuyerName.FromString(cmd.BuyerName))),

                _ => Task.CompletedTask
            };
      
        private async Task HandleCreate(V1.CreateLease cmd)
        {
            if (await _repository.LeaseOrderExists(cmd.LeaseId))
                throw new InvalidOperationException($"Entity with id {cmd.LeaseId} already exists");

            var lease = new LeaseOrder(
                    new LeaseOrderId( cmd.LeaseId),
                    new BuyerId(cmd.BuyerId),
                    new DateCreated( DateTime.UtcNow),
                    new IsDelivery( cmd.IsDelivery),
                    new IsPaid(cmd.IsPaid),
                    new Street( cmd.Street),
                    new ZipCode( cmd.ZipCode),
                    new City(cmd.City)

                );

            await _repository.AddLeaseOrder(lease);
            await _unitOfWork.Commit();
        }

        private async Task HandleCreateLeaseOrderLine(LeaseOrderLineCommands.V1.AddLeaseOrderLineToLeaseOrder cmd)
        {
            if (await _repository.LeaseOrderLineExists(cmd.LeaseOrderLineId))
                throw new InvalidOperationException($"Entity with id {cmd.LeaseOrderLineId} already exists");

            var leaseOrderLine = new LeaseOrderLine(
                   new LeaseOrderLineId( cmd.LeaseOrderLineId),
                   new LeaseOrderId( cmd.LeaseId),
                   new ResourceId( cmd.ResourceId),
                   new StartDate( cmd.StartDate),
                   new EndDate( cmd.EndDate),
                   new IsReturned( cmd.IsReturned),
                   new ResourceName( cmd.ResourceName),
                   new ResourcePrice( cmd.ResourcePrice),
                   new Quantity( cmd.Quantity)

                );

            await _repository.AddLeaseOrderLine(leaseOrderLine);
            await _unitOfWork.Commit();
        }

        private async Task HandleCreateBuyer(BuyerCommands.V1.CreateBuyer cmd)
        {
            if (await _repository.BuyerExists(cmd.BuyerId))
                throw new InvalidOperationException($"Entity with id {cmd.BuyerId} already exists");

            var buyer = new Buyer(
                new BuyerId(cmd.BuyerId),
                BuyerName.FromString(cmd.BuyerName)
                );

            await _repository.AddBuyer(buyer);
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

        private async Task HandleUpdateBuyer(Guid buyerId, Action<Buyer> operation)
        {
            var buyer = await _repository.LoadBuyer(buyerId);

            if (buyer == null)
                throw new InvalidOperationException($"Entity with id {buyerId} cannot be found");

            operation(buyer);

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


        private async Task HandleDeleteBuyer(Guid id)
        {
            var entity = await _repository.LoadBuyer(id);

            if (entity == null)
                throw new InvalidOperationException($"Entity with id {id} cannot be found");

            await _repository.DeleteBuyer(id);

            await _unitOfWork.Commit();
        }
    }
}