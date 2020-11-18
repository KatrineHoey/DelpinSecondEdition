using System.Collections.Generic;
using Resource.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Resource.Microservice.Projections;

namespace Resource.Microservice.Resource
{
    [Route("/resource")]
    public class ResourceQueryApi : Controller
    {
        private static ILogger _log = Log.ForContext<ResourceQueryApi>();

        private readonly IEnumerable<ReadModels.ResourceDetails> _items;
            
        public ResourceQueryApi(IEnumerable<ReadModels.ResourceDetails>items)
            => _items = items;

        [HttpGet]
        public IActionResult Get(QueryModels.GetPublicResource request)
            => RequestHandler.HandleQuery(() => _items.Query(request), _log);
    }
}
