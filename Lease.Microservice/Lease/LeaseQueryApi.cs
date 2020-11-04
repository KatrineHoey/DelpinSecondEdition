using System.Data.Common;
using System.Threading.Tasks;
using Lease.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Lease.Microservice.Lease
{
    [Route("/lease")]
    public class LeaseQueryApi : Controller
    {
        private static ILogger _log = Log.ForContext<LeaseQueryApi>();
        
        private readonly DbContext _connection;

        public LeaseQueryApi(LeaseDbContext connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public Task<IActionResult> GetLeaseById(QueryModels.GetLeaseById request)
        {
            return RequestHandler.HandleQuery(() => _connection.Query(request), _log);
        }
    }
}