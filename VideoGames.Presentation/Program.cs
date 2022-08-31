var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddLoggingConfiguration(hostBuilder: builder.Host);

    services.AddDatabaseConfiguration(configuration: builder.Configuration);

    services.AddSwaggerConfiguration();

    services.AddServices();

    services.AddMediatRConfiguration();

    services.AddControllers();
}

void Configure(WebApplication app)
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.UseSwaggerSetup();
}