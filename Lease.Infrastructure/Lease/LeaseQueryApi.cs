using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
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
            => _connection = connection;

        [HttpGet]
        public Task<IActionResult> Get(QueryModels.GetLease request)
            => RequestHandler.HandleQuery(() => _connection.Query(request), _log);
    }
}