namespace Sample.WebJob
{
  using System.Threading.Tasks;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.Hosting;

  class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = new HostBuilder()
        .ConfigureAppConfiguration(config =>
        {
          // Adding command line as a configuration source
          config.AddCommandLine(args);
        })
        .UseWebJobsStartup<Startup>();

      IHost jobHost = builder.Build();

      using (jobHost)
      {
        await jobHost.RunAsync();
      }
    }
  }
}
