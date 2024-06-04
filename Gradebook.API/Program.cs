using NLog;
using NLog.Web;
using Gradebook.Infrastructure;
using Gradebook.App;
using Gradebook.Presenntation;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try {
    var builder = WebApplication.CreateBuilder(args);

    //nlog 
    builder.Logging.ClearProviders();
    //builder.Host.UseNLog();

    // Add services to the container.

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddAplication();
    builder.Services.AddPresentation();

    builder.Host.UseInfrastructure(); 


    var app = builder.Build();

    // Configure the HTTP request pipeline.

    app.UsePresentation();

    app.Run();

} catch (Exception exception) {
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
} finally {
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}