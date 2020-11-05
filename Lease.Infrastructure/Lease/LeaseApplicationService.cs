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

                V1.UpdateLeaseStreet cmd => HandleUpdate(cmd.LeaseId,
                        c => c.LeaseStreetUpdate(Street.FromString(cmd.Street))),

                V1.UpdateLeaseZipCode cmd => HandleUpdate(cmd.LeaseId,
                        c => c.LeaseZipCodeUpdate(ZipCode.FromInt(cmd.ZipCode))),

                V1.UpdateLeaseCity cmd => HandleUpdate(cmd.LeaseId,
                        c => c.LeaseCityUpdate(City.FromString(cmd.City))),

                V1.UpdateDateCreated cmd => HandleUpdate(cmd.LeaseId,
                        c => c.DateCreatedUpdated(DateCreated.FromDateTime(cmd.DateCreated))),

                V1.DeleteLease cmd => HandleUpdate(cmd.LeaseId,
                        c => c.LeaseDeleted(IsDeleted.FromBool(cmd.IsDeleted))),

                V1.UpdateIsDelivery cmd => HandleUpdate(cmd.LeaseId,
                        c => c.IsDeliveryUpdated(IsDelivery.FromBool(cmd.IsDelivery))),

                V1.UpdateIsPaid cmd => HandleUpdate(cmd.LeaseId,
                        c => c.IsPaidUpdated(IsPaid.FromBool(cmd.IsPaid))),

                V1.UpdateTotalPrice cmd => HandleUpdate(cmd.LeaseId,
                        c => c.TotalPriceUpdated(TotalPrice.FromDecimal(cmd.TotalPrice))),

                _ => Task.CompletedTask
            };
      
        private async Task HandleCreate(V1.CreateLease cmd)
        {
            if (await _repository.LeaseOrderExists(cmd.LeaseId.ToString()))
                throw new InvalidOperationException($"Entity with id {cmd.LeaseId} already exists");

            var lease = new LeaseOrder(
                    new LeaseId(cmd.LeaseId),
                    new DateCreated(cmd.DateCreated),
                    new IsDelivery(cmd.IsDelivery),
                    new IsPaid(cmd.IsPaid),
                    new Street(cmd.Street),
                    new ZipCode(cmd.ZipCode),
                    new City(cmd.City)

                );

            await _repository.AddLeaseOrder(lease);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid leaseId,Action<LeaseOrder> operation)
        {
            var lease = await _repository.LoadLeaseOrder(leaseId.ToString());

            if (lease == null)
                throw new InvalidOperationException($"Entity with id {leaseId} cannot be found");

            operation(lease);

            await _unitOfWork.Commit();
        }
    }
}