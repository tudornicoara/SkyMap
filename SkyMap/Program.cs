using SkyMap.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod()
            .AllowCredentials().WithOrigins("https://localhost:5173");
        policy.AllowAnyHeader().AllowAnyMethod().
            AllowCredentials().WithOrigins("http://localhost:5173");
    });
});

builder.AddAplicationServices();

var app = builder.Build();

// Seeding and migrating the database
ApplicationServiceExtensions.MigrateAndSeedDatabase(app.Services);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("CorsPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();