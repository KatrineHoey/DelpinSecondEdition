using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using static System.Environment;
using static System.Reflection.Assembly;

namespace Resource.Microservice
{
    //public class Program
    //{
    //    static Program() =>
    //        CurrentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location);

    //    public static void Main(string[] args)
    //    {
    //        CreateHostBuilder(args).Build().Run();
    //    }

    //    private static IConfiguration BuildConfiguration(string[] args)
    //=> new ConfigurationBuilder()
    //    .SetBasePath(CurrentDirectory)
    //    .AddJsonFile("appsettings.json", false, false)
    //    .Build();

    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
    //        Host.CreateDefaultBuilder(args)
    //            .ConfigureWebHostDefaults(webBuilder =>
    //            {
    //                webBuilder.UseStartup<Startup>();
    //            });
    //}
    public static class Program
    {
        static Program() =>
            CurrentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location);

        public static void Main(string[] args)
        {
            var configuration = BuildConfiguration(args);

            ConfigureWebHost(configuration).Build().Run();
        }

        private static IConfiguration BuildConfiguration(string[] args)
            => new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .AddJsonFile("appsettings.json", false, false)
                .Build();

        private static IWebHostBuilder ConfigureWebHost(
            IConfiguration configuration)
            => new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .UseContentRoot(CurrentDirectory)
                .UseKestrel();
    }
}
