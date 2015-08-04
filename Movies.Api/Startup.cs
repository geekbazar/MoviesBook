using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(Movies.Api.Startup))]

namespace Movies.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNinjectMiddleware(NinjectConfig.CreateKernel)
               .UseNinjectWebApi(WebApiConfig.Register());
        }
    }
}
