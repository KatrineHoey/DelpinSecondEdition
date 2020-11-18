using Delpin.Framework;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Shared
{
    public class RavenDbUnitOfWork : IUnitOfWork
    {
        private readonly IAsyncDocumentSession _session;

        public RavenDbUnitOfWork(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public Task Commit()
        {
            return _session.SaveChangesAsync();
        }
    }
}
