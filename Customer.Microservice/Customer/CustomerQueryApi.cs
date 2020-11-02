using Customer.Microservice.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Session;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Customer
{
    [Route("/customer")]
    public class CustomerQueryApi : Controller
    {
        private static readonly ILogger _log = Log.ForContext<CustomerQueryApi>();

        private readonly IAsyncDocumentSession _session;

        public CustomerQueryApi(IAsyncDocumentSession session)
        {
            _session = session;
        }

        [HttpGet]
        [Route("search")]
        public Task<IActionResult> Get(QueryModels.GetSearchedActiveCustomers request)
        {
            return RequestHandler.HandleQuery(() => _session.Query(request), _log);
        }

        [HttpGet]
        public Task<IActionResult> Get(QueryModels.GetCustomerById request)
        {
            return RequestHandler.HandleQuery(() => _session.Query(request), _log);
        }
    }
}
