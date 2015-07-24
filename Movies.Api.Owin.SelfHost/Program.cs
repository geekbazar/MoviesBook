using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Movies.Api.Owin.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Server Configuration
            StartOptions serverOptions = new StartOptions();
            serverOptions.Port = 4747;
            serverOptions.Urls.Add("localhost");

            Console.WriteLine("Starting web server");
            WebApp.Start<Startup>(serverOptions);
            Console.WriteLine("Server running at {0} - press enter to quit.", serverOptions.Port);
            Console.ReadLine();
            #endregion

            #region Client Configuration
            
            #endregion
        }
    }
}
