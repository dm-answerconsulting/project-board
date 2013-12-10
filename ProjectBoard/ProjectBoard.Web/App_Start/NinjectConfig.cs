using Ninject;
using Ninject.Modules;
using ProjectBoard.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjectBoard.Web
{
    public static class NinjectConfig
    {
        public static void RegisterDependencyResolver(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            RegisterServices(kernel);

            config.DependencyResolver = new LocalNinjectDependencyResolver(kernel);                        
        }

        public static void RegisterServices(IKernel kernel)
        {
            ProjectBoard.Core.Service.Bindings.ServiceBinding.Load(kernel);
            ProjectBoard.Core.Data.Bindings.DataBinding.Load(kernel);
        }
    }
}