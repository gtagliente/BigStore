using BigStoreCore.Interface;
using BigStoreCore.Logics;
using BigStoreCore.Models;
using BigStoreCore_CustomerExtended;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(wb =>
    {
        wb.UseIISIntegration();
        wb.UseKestrel();
        //wb./*UseStartup*/<Startup>();
        wb.UseSetting("detailedErrors", "true");
        wb.CaptureStartupErrors(true);
        wb.UseIISIntegration();
        wb.UseStartup<StartupBase>();
    }
    );

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
//builder.Services.AddSingleton < IMainBusinessLayer,MockBusinessLayer > ();
builder.Host.UseSerilog(Log.Logger);
builder.Services.AddScoped<IMainBusinessLayer, EFBusinessLayer_CustomerExtended>();

builder.Services.AddDbContext<BigStoreContext>(options =>
{
    options.UseSqlServer(config.GetSection("ConnectionStrings")["DBConnection"]);
});


//builder.Services.AddScoped<Product>( options => { 
//    Product product = new Product();
//    product.Name = "Name";
//    return product; });

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.UseAllOfToExtendReferenceSchemas();
    } );

builder.Services.AddCors();
var app = builder.Build();

app.UseDeveloperExceptionPage();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

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
    name: "BigStore",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();