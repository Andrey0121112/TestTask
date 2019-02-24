using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestTask.Server.LibServer;

namespace TestTask.Server
{
    public class Program
    {
        private static string folder = "Data";

        public static void Main(string[] args)
        {
            string dbDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
            if (!Directory.Exists(dbDir))
            {
                Directory.CreateDirectory(dbDir);
                Json.SaveJson(new List<Phone>(), dbDir + "\\");
            }


            var configuration = new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(configuration)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }


        private static string pathToFolder()
        {
            Directory.CreateDirectory(folder);
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + folder;
        }
    }
}
