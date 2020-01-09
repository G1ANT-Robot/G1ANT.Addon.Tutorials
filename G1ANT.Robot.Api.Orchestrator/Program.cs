using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace G1ANT.Robot.Api.Orchestrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile(
                        "robots.json", optional: false, reloadOnChange: false);
                    config.AddJsonFile(
                        "user.robots.json", optional: true, reloadOnChange: false);
                    config.AddCommandLine(args);
                    var robots = config.Build().GetSection("Robots");
                    foreach(var section in robots.GetChildren())
                    {
                        Data.Robot robot = new Data.Robot();
                        section.Bind(robot);
                        robot.Name = section.Key;
                        Data.Data.Robots.Add(robot);
                    }
                    
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
