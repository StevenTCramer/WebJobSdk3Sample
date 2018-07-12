namespace Sample.WebJob
{
  using System.IO;
  using System.Net.Http;
  using Microsoft.Azure.WebJobs;
  using Microsoft.Extensions.Logging;


  public class SampleJob
  {
    private ILogger Logger { get; }
    private HttpClient HttpClient { get; }

    public SampleJob(
      ILoggerFactory aLoggerFactory,
      HttpClient aHttpClient)
    {
      this.Logger = aLoggerFactory.CreateLogger<SampleJob>();
      this.HttpClient = aHttpClient;
    }

    public void Handle()
    {
      this.Logger.LogInformation($"Use the HttpClient here");
    }

    const string EveryDayAt1AM = "0 0 1 * * *";

    [Singleton]
    public void Process([TimerTrigger(EveryDayAt1AM, RunOnStartup = true)] TimerInfo timerInfo, TextWriter log)
    {
      Handle();
      this.Logger.LogInformation($"Processed work item");
    }
  }
}
