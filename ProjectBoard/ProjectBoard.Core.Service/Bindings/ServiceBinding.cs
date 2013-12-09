using ProjectBoard.Core.Service.Contracts;
using ProjectBoard.Core.Service.Entities;
using Ninject;
using Ninject.Web.Common;

namespace ProjectBoard.Core.Service.Bindings
{
    public class ServiceBinding
    {
        public static void Load(IKernel kernel)
        {            
            // BINDING TAG

            kernel.Bind<IQueryService>().To<QueryService>().InRequestScope();
            kernel.Bind(typeof(ICreateService<>)).To(typeof(CreateService<>)).InRequestScope();
            kernel.Bind(typeof(IUpdateService<>)).To(typeof(UpdateService<>)).InRequestScope();
            kernel.Bind(typeof(IRemoveService<>)).To(typeof(RemoveService<>)).InRequestScope();
            kernel.Bind(typeof(IService<>)).To(typeof(Service<>)).InRequestScope();
        }
    }
}
