using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using static Lease.Infrastructure.ReadModels;

namespace Lease.Infrastructure
{
    public static class Queries
    {
        //String passer ikke-------------------------------------------------------------------------------------

        public static Task<LeaseDetails> Query(
            this DbConnection connection,
            QueryModels.GetLease query)
            => connection.QuerySingleOrDefaultAsync<LeaseDetails>(
                "SELECT \"ClassifiedAdId\", \"Price_Amount\" price, \"Title_Value\" title, " +
                "\"Text_Value\" description, \"DisplayName_Value\" sellersdisplayname " +
                "FROM \"ClassifiedAds\", \"UserProfiles\" " +
                "WHERE \"ClassifiedAdId\" = @Id AND \"OwnerId_Value\"=\"UserProfileId\"",
                new { Id = query.LeaseId });

        //---------------------------------------------------------------------------------------------------------
    }
}