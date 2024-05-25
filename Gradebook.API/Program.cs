using Gradebook.Infrastructure;
using Gradebook.App;
using Gradebook.Presenntation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAplication();
builder.Services.AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UsePresentation();

app.Run();
