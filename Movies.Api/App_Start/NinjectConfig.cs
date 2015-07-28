using Movies.Domain.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Movies.Api
{
    public class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Load(Assembly.GetExecutingAssembly());
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind<IMovie>().To<MoviesRepository>();
        }
    }
}