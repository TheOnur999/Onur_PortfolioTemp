using Onur_PortfolioTemp;
using Data;
using Microsoft.EntityFrameworkCore;

using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DevConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString)
);

//builder.Services.AddDbContext<AppDbContext>(opt =>
//    opt.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27))) // Replace with your actual server version
//);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//ÖnYüz
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Admin Panel 
app.MapControllerRoute(
    name: "areas",
    pattern: "{area}/{controller=Default}/{action=Index}/{id?}"
    );

app.Run();
