using HOA.Models;
using HOA.Repositories;
using HOA.Repositories.Interfaces;
using HOA.Services;
using HOA.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using HOA.Data;
using Microsoft.AspNetCore.Identity;
using HOA.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<HOAUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<HOAContext>();

builder.Services.AddDbContext<HOAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IResidentsService, ResidentsService>();
builder.Services.AddScoped<IPaymentsService, PaymentsService>();
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();
builder.Services.AddScoped<IAnnouncementsService, AnnouncementsService>();
builder.Services.AddScoped<IEventsService, EventsService>();


builder.Services.AddScoped<IResidentsRepository, ResidentsRepository>();
builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
builder.Services.AddScoped<IAnnouncementsRepository, AnnouncementsRepository>();
builder.Services.AddScoped<IEventsRepository, EventsRepository>();


builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();


builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User Settings
    options.User.RequireUniqueEmail = true;
});

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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.UseAuthentication();

app.MapRazorPages();

app.Run();
