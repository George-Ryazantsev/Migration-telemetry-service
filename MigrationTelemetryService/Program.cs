using MigrationTelemetryService.Repository;
using MigrationTelemetryService.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

/*// Add services to the container.
builder.Services.AddControllersWithViews();*/

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    return new MongoClient("mongodb://localhost:27017");
});

builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("metrics_db");
});

builder.Services.AddScoped<IMetricsRepository, MetricsRepository>();
builder.Services.AddScoped<IMetricsService, MetricsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();
