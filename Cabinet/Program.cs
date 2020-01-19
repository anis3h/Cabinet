using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Cabinet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
    }

    //    public static void Main(string[] args)
    //    {
    //        CreateHostBuilder(args).Build().Run();
    //    }

    //    public static IHostBuilder CreateHostBuilder(string[] args)
    //    {
    //        var config = new ConfigurationBuilder()
    //         .AddCommandLine(args)
    //         .AddJsonFile("appsettings.json", true)
    //         .Build();


    //        //return Host.CreateDefaultBuilder(args)
    //        //     .ConfigureWebHostDefaults(webBuilder =>
    //        //     {
    //        //         webBuilder.UseStartup<Startup>();
    //        //     });

    //        var host = new HostBuilder()
    //    .UseContentRoot(Directory.GetCurrentDirectory())
    //    .ConfigureWebHostDefaults(webBuilder =>
    //    {
    //        webBuilder.UseKestrel(serverOptions =>
    //        {
    //            serverOptions.
    //                // Set properties and call methods on options
    //            })
    //        //.UseIISIntegration()
    //        .UseStartup<Startup>();
    //    });
    //        return host;

    //        //return Host.CreateDefaultBuilder(args)
    //        //    //.UseIISIntegration()
    //        //    .UseKestrel()
    //        //    .UseConfiguration(config)
    //        //    .UseStartup<Startup>();
    //    }
    //    //=>
    //    //    WebHost.CreateDefaultBuilder(args)
    //    //        .UseStartup<Startup>()
    //    //        .Build();
    //}
}
