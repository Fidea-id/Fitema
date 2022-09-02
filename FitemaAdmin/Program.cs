using FitemaAdmin.Services;
using FitemaAdmin.Services.Contracts;
using FitemaAdmin.Services.Impl;
using FitemaEntity.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

services.AddSingleton<IUriService>(provider =>
{
    var uri = new URIModel();
    var keyEnvironment = configuration["MyAppSettings:Environment"];
    if (keyEnvironment == "LOCAL")
    {
        uri.ApiUrl = "https://localhost:7249/";
    }
    else if (keyEnvironment == "PRODUCTION")
    {
        uri.ApiUrl = "-";
    }
    else
    {
        throw new Exception("Environment invalid");
    }

    return new UriService(uri);
});

services.AddScoped<IRestRequestService, RestRequestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
