using FastEndpoints;
using FastEndpoints.Swagger;
using Secretary.Application;
using Secretary.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
  .AddProblemDetails()
  .AddFastEndpoints()
  .SwaggerDocument()
  .AddApplicationServices()
  .AddInfrastructureServices();

var app = builder.Build();
app
  .UseExceptionHandler()
  .UseFastEndpoints(config =>
  {
    config.Endpoints.RoutePrefix = "api";
    config.Endpoints.Configurator = configurator => configurator.AllowAnonymous();
  })
  .UseSwaggerGen();
app.Run();


public class HelloWorldEndpoint : EndpointWithoutRequest
{
  public override void Configure()
  {
    Get("/");
  }

  public override async Task HandleAsync(CancellationToken ct) => await SendAsync("Hello world!", cancellation: ct);
}