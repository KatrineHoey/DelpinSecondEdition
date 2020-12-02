using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delpin.Shared.ResourceModels;
using Resource.Infrastructure;


namespace Resource.Intrastructure.Query
{
    public static class Queries
    {
        public static ReadModels.ResourceDetails GetById(this IEnumerable<ReadModels.ResourceDetails> items, QueryModels.GetPublicResource query)
        {
            return items.Where(x => x.ResourceId == query.ResourceId).FirstOrDefault();
        }

        public static List<ReadModels.ResourceDetails> All(
            this IEnumerable<ReadModels.ResourceDetails> items)
            => items.Where(x => x.IsDeleted == false).ToList();

        public static List<ReadModels.ResourceDetails> Search(this IEnumerable<ReadModels.ResourceDetails> items, QueryModels.Search query)
        {
            return items.Where(x => x.ResourceName == query.Searchterm && x.IsDeleted == false).ToList();
        }
    }
}