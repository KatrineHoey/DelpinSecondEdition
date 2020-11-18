using System.Collections.Generic;
using System.Linq;
using Resource.Microservice.Projections;

namespace Resource.Microservice.Resource
{
    public static class Queries
    {
        public static ReadModels.ResourceDetails Query(
            this IEnumerable<ReadModels.ResourceDetails> items,
            QueryModels.GetPublicResource query)
            => items.FirstOrDefault(x => x.ResourceId == query.ResourceId);
    }
}
