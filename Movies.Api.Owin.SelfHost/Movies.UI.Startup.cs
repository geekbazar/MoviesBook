using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IO;
using System.Reflection;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;

[assembly: OwinStartup(typeof(Movies.Api.Owin.SelfHost.ClientConfiguration))]

namespace Movies.Api.Owin.SelfHost
{
    public class ClientConfiguration
    {
        public void Configuration(IAppBuilder app)
        {
            string clientPath = Path.Combine(Directory.GetParent(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName).FullName, "Movies.UI");

            var fileServerOptions = new FileServerOptions
                                            {
                                                EnableDefaultFiles = true,
                                                FileSystem = new PhysicalFileSystem(clientPath)
                                            };
            fileServerOptions.StaticFileOptions.FileSystem = new PhysicalFileSystem(clientPath);
            fileServerOptions.StaticFileOptions.ServeUnknownFileTypes = true;
            fileServerOptions.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };


            app.UseFileServer(fileServerOptions);
        }
    }
}
