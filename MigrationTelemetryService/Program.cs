using MigrationTelemetryService.Services;
using ServiceCloud.Extensions.Logging.File;

var builder = WebApplication.CreateBuilder(args);

/*// Add services to the container.
builder.Services.AddControllersWithViews();*/

builder.Logging.AddJsonFileLogger(options=> options.FilePath = "C:\\Users\\g.ryazancev\\Desktop\\Metrics\\metrics.txt");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IMetricsRepository, MetricsRepository>();
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
