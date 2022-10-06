
using ProjectOftrans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
namespace ProjectOftrans
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var progData=Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            Log.Logger=new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(progData,"ProjectDemo","Servicelog.txt"))
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
