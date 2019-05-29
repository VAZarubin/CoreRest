using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Con1
{
    public class Program
    {
        #region Static Methods

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Limits.MaxConcurrentConnections = 100;
                    options.Limits.MaxRequestBodySize = 10 * 1024;
                    options.Limits.MinRequestBodyDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));
                    options.Limits.MinResponseDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));
                    options.Listen(IPAddress.Loopback, 5000);
                })
                .Build();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BuildWebHost(args)
                .Run();

            Console.Read();
        }

        #endregion
    }
}
