using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lease.Infrastructure
{
    [Route("/lease")]
    public class LeaseQueryApi : Controller
    {
        private static ILogger _log = Log.ForContext<LeaseQueryApi>();
        
        private readonly DbConnection _connection;

        public LeaseQueryApi(DbConnection connection)
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