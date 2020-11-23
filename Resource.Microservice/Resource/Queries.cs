using System.Collections.Generic;
using System.Linq;
using Resource.Microservice.Projections;

namespace Resource.Microservice.Resource
{
    public static class Queries
    {
        public static ReadModels.ResourceDetails Query(this IEnumerable<ReadModels.ResourceDetails> items, QueryModels.GetPublicResource query)
        {
            return items.Where(x => x.ResourceId == query.ResourceId).FirstOrDefault();
        }


        public static List<ReadModels.ResourceDetails> All(
            this IEnumerable<ReadModels.ResourceDetails> items)
            => items.Where(x => x.IsDeleted == false).ToList();
    }
}
//lav en ny get metode, der henter alle resourcer, som ikke er slettet