using Kolpi.ApplicationCore.Entities;
using Kolpi.Infrastructure.Data;
using Kolpi.Server.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews();
builder.Services
    .AddRazorPages();

builder.Services
    .AddDbContext<KolpiDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:KolpiSqlServerConnection").Value));

//builder.Services
//    .AddDefaultIdentity<KolpiUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<KolpiDbContext>();

//builder.Services
//    .AddIdentityServer()
//    .AddApiAuthorization<KolpiUser, KolpiDbContext>();

//builder.Services
//    .AddAuthentication()
//    .AddIdentityServerJwt();

// DI registrations
builder.Services
    .AddKolpiServices()
    .AddKolpiLogger()
    .AddKolpiEmailSender();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

//app.UseIdentityServer();
//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");;

app.Run();

public partial class Program 
{ 
}
