using System;
using System.Threading.Tasks;
using Delpin.Framework;
using Lease.Domain.Shared;
using Lease.Domain;
using static Lease.Infrastructure.Commands;
using System.Runtime.Intrinsics;

namespace Lease.Infrastructure
{
    public class LeaseApplicationService : IApplicationService
    {
        private readonly ILeaseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrencyLookup _currencyLookup;

        public LeaseApplicationService(
            ILeaseRepository repository, IUnitOfWork unitOfWork,
            ICurrencyLookup currencyLookup
        )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _currencyLookup = currencyLookup;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateLease cmd =>
                    HandleCreate(cmd),

                //V1.UpdateLeaseAdresse cmd =>
                //HandleUpdate(
                //    cmd.LeaseId,
                //    c => c.LeaseAdresseUpdate(
                //        Adresse.FromString(cmd.Street, cmd.ZipCode, cmd.City))
                //    ),

                //V1.UpdateDateCreated cmd =>
                //HandleUpdate(
                //    cmd.LeaseId,
                //    c => c.DateCreatedUpdated(
                //        DateCreated.FromDateTime(cmd.DateCreated)
                //    ),

                //V1.DeleteLease cmd =>
                //    HandleUpdate(
                //    cmd.LeaseId,
                //    c => c.LeaseDeleted(
                //        IsDeleted.FromBool(cmd.IsDeletet)
                //    ),

                //V1.UpdateIsDelivery cmd =>
                //    HandleUpdate(
                //        cmd.LeaseId,
                //        c => c.IsDeliveryUpdated(
                //            IsDelivery.FromBool(cmd.IsDelivery)
                //     ),

                //V1.UpdateIsPaid cmd =>
                //    HandleUpdate(
                //        cmd.LeaseId,
                //        c => c.IsPaidUpdated(
                //            IsDelivery.FromBool(cmd.IsPayed)
                //     ),

                //V1.UpdateTotalPrice cmd =>
                //    HandleUpdate(
                //    cmd.LeaseId,
                //    c => c.TotalPriceUpdated(
                //        TotalPrice.FromDecimal(cmd.TotalPrice)
                //        ),

                //V1.RequestToPublish cmd =>
                //    HandleUpdate(
                //        cmd.leaseId,
                //        c => c.RequestToPublish()
                //    ),

                //V1.Publish cmd =>
                //    HandleUpdate(
                //        cmd.Id, c =>
                //            c.Publish(new LeaseId(cmd.ApprovedBy))
                //    ),
                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateLease cmd)
        {
            if (await _repository.Exists(cmd.LeaseId.ToString()))
                throw new InvalidOperationException(
                    $"Entity with id {cmd.LeaseId} already exists"
                );

            var lease =
                new Domain.Lease(
                    new LeaseId(cmd.LeaseId),
                    new Adresse(new Street(cmd.Street),new ZipCode(cmd.ZipCode),new City(cmd.City)),
                    new DateCreated(cmd.DateCreated),
                    new IsDeleted(cmd.IsDeleted),
                    new IsDelivery(cmd.IsDelivery),
                    new IsPaid(cmd.IsPaid),
                    new TotalPrice(cmd.TotalPrice)
                    
                );

            await _repository.Add(lease);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid leaseId,Action<Domain.Lease> operation)
        {
            var lease = await _repository
                .Load(leaseId.ToString());

            if (lease == null)
                throw new InvalidOperationException(
                    $"Entity with id {leaseId} cannot be found"
                );

            operation(lease);

            await _unitOfWork.Commit();
        }
    }
}