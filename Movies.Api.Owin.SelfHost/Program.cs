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
            Console.WriteLine("Server running at {0}", serverOptions.Port);
            #endregion

            #region Client Configuration

            StartOptions clientOptions = new StartOptions();
            clientOptions.Port = 7474;
            clientOptions.Urls.Add("localhost");

            Console.WriteLine("Starting web client");
            WebApp.Start<ClientConfiguration>(clientOptions);
            Console.WriteLine("Client running at {0} - press enter to quit.", clientOptions.Port);
            Console.ReadLine();
            #endregion
        }
    }
}
