using BigStoreCore.Interfaces;
using BigStoreCore.Logic;
using BigStoreCore.Models;
using BigStoreCore_CustomerExtended;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton < IMainBusinessLayer,MockBusinessLayer > ();
builder.Services.AddScoped<IMainBusinessLayer, EFBusinessLayer_CustomerExtended>();

builder.Services.AddDbContext<BigStoreContext>(options =>
{
    options.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DBConnection"]);
});
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();