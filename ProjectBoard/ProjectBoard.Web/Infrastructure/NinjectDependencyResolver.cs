using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace ProjectBoard.Web.Infrastructure
{
    public class LocalNinjectDependencyResolver : IDependencyResolver
    {
        #region .ctor

        public LocalNinjectDependencyResolver(StandardKernel kernel)
        {
            _kernel = kernel;
        }

        #endregion

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            var service = _kernel.TryGet(serviceType);

            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                var list = _kernel.GetAll(serviceType);

                return list;
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        private readonly StandardKernel _kernel;
    }
}