using Microsoft.EntityFrameworkCore;
using SkyMap.Data;
using SkyMap.Interfaces;
using SkyMap.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod()
            .AllowCredentials().WithOrigins("https://localhost:4200");
        policy.AllowAnyHeader().AllowAnyMethod().
            AllowCredentials().WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddTransient<IDiscoverySourceTypeRepository, DiscoverySourceTypeRepository>();
builder.Services.AddTransient<ICelestialObjectTypeRepository, CelestialObjectTypeRepository>();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("CorsPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();