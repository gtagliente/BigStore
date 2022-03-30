using BigStoreCore.Interfaces;
using BigStoreCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//var assemblyPath = @"C:\Users\Samsung\Documents\Gianluca\Git_Sources\BigStore\source\BigStore\EFBigStoreLogic\bin\Debug\net6.0\EFBigStoreLogic.dll";
var assemblyPath = @"C:\Users\Samsung\Documents\Gianluca\Git_Sources\BigStore\source\BigStore\MockBigStoreCore\bin\Debug\net6.0\MockBigStoreLogic.dll";
//var typeName = "EFBusinessLayer";
var typeName = "MockBusinessLayer";

var assembly = Assembly.LoadFrom(assemblyPath);
// Così non funziona :(
//Type LogicType = assembly.GetType(typeName);


Type LogicType = assembly.GetTypes().Where(t => t.Name == typeName).FirstOrDefault();


//var serviceProvider = new ServiceCollection()
//    .AddTransient(typeof(IDILogger), loggerType)
//    .BuildServiceProvider();

//var logger = serviceProvider.GetService<IDILogger>();



//builder.Services.AddSingleton < IMainBusinessLayer,MockBusinessLayer > ();
builder.Services.AddScoped(typeof(IMainBusinessLayer), LogicType);

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
