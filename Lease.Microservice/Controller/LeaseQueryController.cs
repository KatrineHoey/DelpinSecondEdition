using System;
using System.Data.Common;
using System.Threading.Tasks;
using Lease.Intrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Lease.Microservice.Lease.Query
{
    [Route("/lease")]
    public class LeaseQueryController : Controller
    {
        private static ILogger _log = Log.ForContext<LeaseQueryController>();
        
        private readonly LeaseOrderQueries _leaseOrderQueries;

        public LeaseQueryController(LeaseOrderQueries leaseOrderQueries)
        {
            _leaseOrderQueries = leaseOrderQueries;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _leaseOrderQueries.GetAllLease();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }


        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> Get(QueryModels.GetLeaseOrderById request)
        {
            try
            {
                var model = await _leaseOrderQueries.GetLeaseById(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("BuyerId")]
        public async Task<IActionResult> Get(QueryModels.GetLeasesByBuyerId request)
        {
            try
            {
                var model = await _leaseOrderQueries.GetLeaseByBuyerId(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Get(QueryModels.GetSearchedLeases request)
        {
            try
            {
                var model = await _leaseOrderQueries.GetSearchedLeases(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("LeaseOrderLineId")]
        public async Task<IActionResult> Get(QueryModels.GetLeaseOrderLineById request)
        {
            try
            {
                var model = await _leaseOrderQueries.GetLeaseOrderLineIdById(request);
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