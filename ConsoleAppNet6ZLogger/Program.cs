// See https://aka.ms/new-console-template for more information

using ConsoleAppNet6ZLogger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZLogger;

Host.CreateDefaultBuilder()
    .ConfigureLogging(logging =>
    {
        // optional(MS.E.Logging):clear default providers.
        logging.ClearProviders();

        // optional(MS.E.Logging): default is Info, you can use this or AddFilter to filtering log.
        logging.SetMinimumLevel(LogLevel.Debug);

        // Add Console Logging.
        logging.AddZLoggerConsole();

        // Add File Logging.
        logging.AddZLoggerFile("log.txt");

        // // Add Rolling File Logging.
        // logging.AddZLoggerRollingFile((dt, x) => $"logs/{dt.ToLocalTime():yyyy-MM-dd}_{x:000}.log",
        //     x => x.ToLocalTime().Date, 1024);
        //
        // // Enable Structured Logging
        // logging.AddZLoggerConsole(options =>
        // {
        //     options.EnableStructuredLogging = true;
        // });
    })
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<MyClass>();

        // インスタンスを提供してくれる人を作る
        using var provider = services.BuildServiceProvider();

        var myService = provider.GetService<MyClass>();
        myService.Foo();
    }).Build();
