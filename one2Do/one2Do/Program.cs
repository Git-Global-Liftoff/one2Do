using Microsoft.EntityFrameworkCore;
using one2Do;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("one2doDbContextConnection") ?? throw new InvalidOperationException("Connection string 'one2doDbContextConnection' not found.");


builder.Services.AddScoped<IWForecastRepository, WForecastRepository>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = "server=localhost;user=one2do;password=gitglobal;database=one2do";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));


builder.Services.AddDbContext<one2doDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<one2doDbContext>();
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

app.MapRazorPages();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
