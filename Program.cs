using Demo_Appsetting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder builder = Host.CreateDefaultBuilder(args).ConfigureHostConfiguration(configHost =>
{
    //使用環境變數來設定組態，進而使appsettings.json 、 appsettings.{Environment}.json 設定被覆蓋
    configHost.AddEnvironmentVariables(prefix: "ASPNETCORE_");
});


IHost host = builder.ConfigureServices((hostContext, services) =>
{
    services.AddSingleton<IWorker, Worker>();
})
.Build();

Console.WriteLine($"Environment variable is: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
Console.WriteLine(host.Services.GetRequiredService<IHostEnvironment>().EnvironmentName);
Console.WriteLine("--------- Service start ---------");
IWorker worker = host.Services.GetService<IWorker>();

worker.Run();

