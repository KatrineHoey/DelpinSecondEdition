using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using static Lease.Infrastructure.ReadModels;

namespace Lease.Infrastructure
{
    public static class Queries
    {
        public static Task<LeaseDetails> Query(this DbConnection connection, QueryModels.GetLeaseById query)
        {
            string sql = "Select * from Leases Where LeaseId = @Id;";

            return connection.QuerySingleOrDefaultAsync<LeaseDetails>(sql,new { Id = query.LeaseId });
        }  
    }
}