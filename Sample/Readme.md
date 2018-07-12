# Referenced Links 
https://github.com/Azure/azure-webjobs-sdk/blob/dev/sample/SampleHost/Program.cs#L21

Repo started with the above link.

Stylecop is in the repo because it is currently a dependency of 
PackageReference Include="Microsoft.Azure.WebJobs.Host.Storage" Version="3.0.0-beta7-11365"

Excuting the app yields

```
      Hosting starting
info: Microsoft.Azure.WebJobs.Hosting.JobHostService[0]
      Starting JobHost
warn: Host.Startup[0]
      No job functions found. Try making your job classes and methods public. If you're using binding extensions (e.g. ServiceBus, Timers, etc.) make sure you've called the registration method for the extension(s) in your startup code (e.g. config.UseServiceBus(), config.UseTimers(), etc.).
info: Host.Startup[0]
      Job host started
Application started. Press Ctrl+C to shut down.
Hosting environment: Development
Content root path: C:\git\github\WebJobSdk3Sample\Sample\bin\Debug\netcoreapp2.1\
dbug: Microsoft.Extensions.Hosting.Internal.Host[2]
      Hosting started

```

The question is how is UseTimers supposed to be added?
