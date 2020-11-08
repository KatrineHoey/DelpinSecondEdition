using System.Data.Common;
using System.Threading.Tasks;
using Lease.Infrastructure;
using Lease.Infrastructure.Lease;
using Lease.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Lease.Microservice.Controllers
{
    [Route("/lease")]
    public class LeaseQueryController : Controller
    {
        private static ILogger _log = Log.ForContext<LeaseQueryController>();
        
        private readonly DbContext _connection;

        public LeaseQueryController(LeaseDbContext connection)
        {
            _connection = connection;
        }

        //LeaseOrder
        [HttpGet]
        public Task<IActionResult> Get()
        {
            return RequestHandler.HandleQuery(() => _connection.GetAllLease(), _log);
        }


        [HttpGet("{LeaseId}")]
        public Task<IActionResult> Get(QueryModels.GetLeaseOrderById request)
        {
            return RequestHandler.HandleQuery(() => _connection.GetLeaseById(request), _log);
        }

        //LeaseOrderLine

        //[HttpGet]
        //public Task<IActionResult> GetAllLeaseOrderLine()
        //{
        //    return RequestHandler.HandleQuery(() => _connection.GetAllLeaseOrderLine(), _log);
        //}


        //[HttpGet("{LeaseOrderLineId}")]
        //public Task<IActionResult> GetLeaseOrderLineById(QueryModels.GetLeaseOrderLineById request)
        //{
        //    return RequestHandler.HandleQuery(() => _connection.GetLeaseOrderLineById(request), _log);
        //}
    }
}