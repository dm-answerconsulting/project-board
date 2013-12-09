using Ninject;
using Ninject.Web.Common;
using ProjectBoard.Core.Data.Context;
using ProjectBoard.Core.Data.Contracts;

namespace ProjectBoard.Core.Data.Bindings
{
    public class DataBinding
    {
        public static void Load(IKernel kernel)
        {
            kernel.Bind<IRepository>().To<Repository>().InRequestScope();
        } 
    }
}