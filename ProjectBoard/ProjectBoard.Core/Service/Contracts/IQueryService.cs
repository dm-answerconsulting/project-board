using System.Linq;
using ProjectBoard.Core.Data.Contracts;

namespace ProjectBoard.Core.Service.Contracts
{
    public interface IQueryService
    {
        IQueryable<T> Query<T>() where T : class, IEntity<T>;

        T Single<T>(params object[] key) where T : class, IEntity<T>;
    }
}