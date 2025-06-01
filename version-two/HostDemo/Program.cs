using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HostDemo;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.Services.AddHostedService<TimeService>();
builder.Services.Configure<HostOptions>(o => {
    o.StartupTimeout = TimeSpan.FromSeconds(5);
    o.ServicesStartConcurrently = true;
});
IHost host = builder.Build();
var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();
//lifetime.ApplicationStarted.Register(() => Console.WriteLine("Hello World"));
await host.RunAsync();