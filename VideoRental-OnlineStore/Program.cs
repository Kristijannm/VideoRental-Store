using VideoRental.InjectionHelper;
using VideoRental.DataAccess.EFImplementations;
using VideoRental.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Session Configuration
builder.Services.AddSession();


//inject services
InjectionHelper.InjectServices(builder.Services);
//inject repositories
InjectionHelper.InjectionRepositories(builder.Services);
//inject DbContext
InjectionHelper.InjectDbContext(builder.Services);

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
//Session Configuration
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
