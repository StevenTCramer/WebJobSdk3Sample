namespace Sample.WebJob
{
  using System;
  using Microsoft.Azure.WebJobs.Host;
  using Microsoft.Extensions.DependencyInjection;

  public class CustomJobActivator : IJobActivator
  {
    private IServiceProvider ServiceProvider { get; }
    public CustomJobActivator(IServiceProvider aServiceProvider)
    {
      ServiceProvider = aServiceProvider;
    }

    public T CreateInstance<T>()
    {
      var service = ServiceProvider.GetService<T>();
      return service;
    }
  }
}