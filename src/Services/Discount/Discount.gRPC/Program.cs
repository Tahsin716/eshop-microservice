using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddGrpc();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8003, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
    options.Listen(IPAddress.Any, 80, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
    options.Listen(IPAddress.Any, 5003, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
