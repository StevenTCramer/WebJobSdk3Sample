namespace Sample.WebJob
{
  using System.Net.Http;
  using Microsoft.Azure.WebJobs.Host;
  using Microsoft.Azure.WebJobs.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using Microsoft.Extensions.Logging;
  using Microsoft.Extensions.Configuration;
  using System.IO;

  public class Startup : IWebJobsStartup
  {
    public Startup()
    {
      Configuration = GetWebJobConfiguration();
    }

    private IConfigurationRoot GetWebJobConfiguration()
    {
      var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddEnvironmentVariables()
          .Build();

      return configuration;
    }

    private IConfiguration Configuration { get; }

    public void Configure(IHostBuilder builder)
    {
      builder
        .UseEnvironment("Development")
        .ConfigureWebJobsHost()
        .AddWebJobsLogging() // Enables WebJobs v1 classic logging 
        .AddAzureStorageCoreServices()
        .AddAzureStorage()
        .ConfigureLogging(b =>
        {
          b.SetMinimumLevel(LogLevel.Debug);
          b.AddConsole();
        })
        .UseConsoleLifetime()
        .ConfigureServices(ConfigureServices);
    }

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddOptions();
      aServiceCollection.AddSingleton<IJobActivator, CustomJobActivator>();
      aServiceCollection.AddSingleton<SampleJob>();


      HttpClient httpClient = new HttpClient()
      {
        BaseAddress = new System.Uri("http://localhost:5000/")
      };

      aServiceCollection.AddSingleton(httpClient);
    }
  }
}
