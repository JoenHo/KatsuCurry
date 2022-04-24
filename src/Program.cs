using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{

    public class Program
    {
        /// <summary>
        /// This is the function for applications to start, serves as
        /// enter point of the application
        /// </summary>
        /// <param name="args"></param> take strings array to mark start point
        public static void Main(string[] args) =>
            // This method creates new instance of HostBuilder
            CreateHostBuilder(args).Build().Run();

        // This method calls UserStartup<start>() method from
        // webBuilder to specify the Startu class to be accessed by web host
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
