using Gradebook.Infrastructure;
using Gradebook.App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAplication();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.Run();
