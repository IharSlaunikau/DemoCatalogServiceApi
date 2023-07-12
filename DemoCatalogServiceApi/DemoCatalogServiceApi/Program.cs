namespace DemoCatalogServiceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(InitializeConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InitializeConfiguration(IConfigurationBuilder builder)
        {
            // appsettings files
            builder.AddJsonFile("appsettings.json", false, true);
            builder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                false, true);

            // environment variables
            builder.AddEnvironmentVariables();
        }
    }
}
