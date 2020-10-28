using System.Threading.Tasks;

namespace Delpin.Framework
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}