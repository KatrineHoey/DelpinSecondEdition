using Delpin.Framework;
using Resource.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Resource.Microservice.Resource.Commands;

namespace Resource.Microservice.Resource
{
    public class ResourceApplicationService : IApplicationService
    {
        private readonly IAggregateStore _store;

        public ResourceApplicationService(IAggregateStore store)
        {
            _store = store;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateResource cmd =>
                HandleCreate(cmd),
                V1.UpdateName cmd =>
                HandleUpdate(cmd.Id,
                    c => c.UpdateName(ResourceName.FromString(cmd.Name)
                        )
                    ),
                V1.UpdateResourceNo cmd =>
                HandleUpdate(cmd.Id,
                    c => c.UpdateResourceNo(ResourceNo.FromInt(cmd.ResourceNo)
                        )
                    ),
                V1.UpdateResourcePrice cmd =>
                HandleUpdate(cmd.Id,
                    c => c.UpdateResourcePrice(ResourcePrice.FromInt(cmd.ResourcePrice)
                        )
                    ),
                V1.ResourceDeleted cmd =>
                HandleUpdate(cmd.Id,
                    c => c.ResourceDeleted(IsDeleted.FromBool(cmd.IsDeleted)
                        )
                    ),
                _ => Task.CompletedTask
            };


        private async Task HandleCreate(V1.CreateResource cmd)
        {
            if (await _store.Exists<Domain.Resource,
                ResourceId>(
                new ResourceId(cmd.Id)
            ))
                throw new InvalidOperationException(
                    $"Entity with id {cmd.Id} already exists");

            var resource = new Domain.Resource(new ResourceId(cmd.Id), ResourceName.FromString(cmd.ResourceName), ResourceNo.FromInt(cmd.ResourceNo), ResourcePrice.FromInt(cmd.ResourcePrice)

            );

            await _store.Save<Domain.Resource, ResourceId>(resource);
        }



        private Task HandleUpdate(
           Guid id,
           Action<Domain.Resource> update
       ) =>
           this.HandleUpdate(
               _store,
               new ResourceId(id),
               update
           );
    }
}
