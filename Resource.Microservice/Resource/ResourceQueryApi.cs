using System;
using System.Collections.Generic;
using Resource.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;
using System.Linq;
using Resource.Intrastructure.Query;
using Delpin.Shared.ResourceModels;

namespace Resource.Microservice.Resource
{
    [Route("/resource")]
    public class ResourceQueryApi : Controller
    {
        private static ILogger _log = Log.ForContext<ResourceQueryApi>();

        private readonly IEnumerable<ReadModels.ResourceDetails> _items;

        public ResourceQueryApi(IEnumerable<ReadModels.ResourceDetails>items)
        {
            _items = items;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetByIdAsync(QueryModels.GetPublicResource request)
        {
            try
            {
                var model = _items.GetById(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {

                return Errorhandling(e);
            }

        }

        [HttpGet]
        [Route("/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = _items.All();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {

                return Errorhandling(e);
            }

        }

        [HttpGet]
        [Route("/Search")]
        public async Task<IActionResult> Search(QueryModels.Search request)
        {
            try
            {
                var model = _items.Search(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {

                return Errorhandling(e);
            }

        }

        private IActionResult Errorhandling(Exception e)
        {
            _log.Error(e, "Error handling the query");
            return new BadRequestObjectResult(new
            {
                error = e.Message,
                stackTrace = e.StackTrace
            });
        }
    }
}
