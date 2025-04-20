using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raja.Infrastracture.Configuratin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

RajaPersonelConfiguration.Configure(builder.Services, builder.Configuration.GetConnectionString("RajaDb"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

if (!RajaConfiguration.Migrate(app.Services))
    return;
app.Run();
