using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddJsonConsole();

builder.Configuration
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);


builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "API Gateway up an running!");

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

await app.UseOcelot();

app.Run();
