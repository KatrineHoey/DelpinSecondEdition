using System.Data.Common;
using System.Threading.Tasks;
using Lease.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Lease.Microservice.Lease
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

        [HttpGet]
        public Task<IActionResult> GetAllLeaseOrder()
        {
            return RequestHandler.HandleQuery(() => _connection.GetAllLease(), _log);
        }


        [HttpGet("{LeaseId}")]
        public Task<IActionResult> GetLeaseOrderById(QueryModels.GetLeaseOrderById request)
        {
            return RequestHandler.HandleQuery(() => _connection.GetLeaseById(request), _log);
        }
    }
}