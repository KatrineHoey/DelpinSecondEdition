using System.Threading.Tasks;

namespace Delpin.Framework
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}