using Delpin.Framework;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Customer.Microservice.Infrastructure
{
    public class RavenDbRepository<T, TId>
        where T : AggregateRoot<TId>
        where TId : Value<TId>
    {
        private readonly Func<TId, string> _entityId;
        private readonly IAsyncDocumentSession _session;

        public RavenDbRepository(
            IAsyncDocumentSession session,
            Func<TId, string> entityId)
        {
            _session = session;
            _entityId = entityId;
        }

        public Task Add(T entity)
        {
            return _session.StoreAsync(entity, _entityId(entity.Id));
        }

        public Task<bool> Exists(TId id)
        {
            return _session.Advanced.ExistsAsync(_entityId(id));
        }

        public async Task<T> Load(TId id)
        {
            var t = await _session.LoadAsync<T>(_entityId(id).ToString());
   
            return t;
        }
    }
}
