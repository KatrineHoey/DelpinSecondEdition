using System.Threading.Tasks;

namespace Delpin.Framework
{
    public interface IProjection
    {
        Task Project(object @event);
    }
}
