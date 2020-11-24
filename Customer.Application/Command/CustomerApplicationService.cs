using Customer.Domain.Customer;
using Delpin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Delpin.Shared.CustomerModels.CustomerCommandsDto;

namespace Customer.Application.Command
{
    public class CustomerApplicationService : IApplicationService
    {
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerApplicationService(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command)
        {
            return command switch
            {
                V1.RegisterCustomer cmd =>
                    HandleCreate(cmd),
                V1.UpdateCustomerFullName cmd =>
                    HandleUpdate(cmd.CustomerId, profile => profile.UpdateName(FullName.FromString(cmd.FullName))),

                V1.UpdateCustomerEmail cmd =>
                    HandleUpdate(
                        cmd.CustomerId,
                        profile => profile.UpdateEmail(
                           Email.FromString(cmd.Email)
                        )
                    ),
                 V1.UpdateCustomerAdresse cmd =>
                    HandleUpdate(
                        cmd.CustomerId,
                        profile => profile.UpdateAdresse(
                          new Adresse(Street.FromString(cmd.Street), ZipCode.FromInt(cmd.ZipCode), City.FromString(cmd.City))
                        )
                    ),
                  V1.ChangeCustomerType cmd =>
                    HandleUpdate(
                        cmd.CustomerId,
                        profile => profile.ChangeCustomerType(
                            CustomerType.FromString(cmd.CustomerType.ToString())
                        )
                    ),
                V1.UpdateCustomerPhoneNo cmd =>
                    HandleUpdate(
                        cmd.CustomerId,
                        profile => profile.UpdatePhoneNo(
                            PhoneNo.FromInt(cmd.PhoneNo)
                        )
                    ),

                 V1.DeleteCustomer cmd =>
                    HandleUpdate(
                        cmd.CustomerId,
                        profile => profile.DeleteCustomer(
                            IsDeleted.FromBool(cmd.IsDeleted)
                        )
                    ),
                _ => Task.CompletedTask
            };
        }

        private async Task HandleCreate(V1.RegisterCustomer cmd)
        {
            if (await _repository.Exists(cmd.CustomerId.ToString()))
                throw new InvalidOperationException(
                    $"Entity with id {cmd.CustomerId} already exists"
                );

            var customer = new Domain.Customer.Customer(
                new CustomerId(cmd.CustomerId),
                FullName.FromString(cmd.FullName),
                Adresse.FromString(cmd.Street, cmd.ZipCode, cmd.City),
                PhoneNo.FromInt(cmd.PhoneNo),
                Email.FromString(cmd.Email),
                CustomerType.FromString(cmd.CustomerType.ToString())
                
            ); ;

            await _repository.Add(customer);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(
            Guid customerId,
            Action<Domain.Customer.Customer> operation
        )
        {
            var customer = await _repository
                .Load(customerId.ToString());
            if (customer == null)
                throw new InvalidOperationException(
                    $"Entity with id {customerId} cannot be found"
                );

            operation(customer);

            await _unitOfWork.Commit();


        }
    }
}
