using SimpleConverter.Service;
using Serilog;
using SimpleConverter.WebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
.MinimumLevel.Warning()
.WriteTo.File("logs/.txt", rollingInterval: RollingInterval.Day, outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
.CreateLogger();

builder.Services.AddLogging();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IConverterService, ConverterService>();
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
