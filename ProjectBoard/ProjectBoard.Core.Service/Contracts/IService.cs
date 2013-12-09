using ProjectBoard.Core.Data.Contracts;

namespace ProjectBoard.Core.Service.Contracts
{
    public interface IService<T> : 
        IQueryService, 
        ICreateService<T>, 
        IUpdateService<T>, 
        IRemoveService<T> 
        where T : class, IEntity<T>
    {        
    }
}