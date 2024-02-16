using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp.Data;


var builder = WebApplication.CreateBuilder(args);

var connectonString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MovieAppContext>(options =>
{
    options.UseMySql(connectonString, ServerVersion.AutoDetect(connectonString));
});
// Add services to the container.
builder.Services.AddControllersWithViews();



// Add services to the container.
//builder.Services.AddScoped<MovieDbContext>(provider =>
  //  new MovieDbContext(builder.Configuration.GetConnectionString("Default")));

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



// Check database connection
CheckDatabaseConnection(app);

app.Run();

// Database connection check method
void CheckDatabaseConnection(IHost app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<MovieAppContext>();
        context.Database.OpenConnection();
        context.Database.CloseConnection();
        Console.WriteLine("Database connection successful!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error connecting to the database: {ex.Message}");
    }
}