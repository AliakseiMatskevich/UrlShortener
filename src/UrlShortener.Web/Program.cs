using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UrlShortener.Infrastructure.Data;
using UrlShortener.Infrastructure.Identity;
using UrlShortener.Web.Interfaces;
using UrlShortener.Web.Services;

var builder = WebApplication.CreateBuilder(args);


#region Configure DbContext
builder.Services.AddDbContext<AppIdentityDBContext>(context => context.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppIdentityDBContext>();
#endregion

#region Configure Serilog
var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
#endregion

#region Configure Identity
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddDefaultUI()
    .AddEntityFrameworkStores<AppIdentityDBContext>()
    .AddDefaultTokenProviders();
#endregion

#region Configure own services
builder.Services.AddScoped(typeof(IUrlService), typeof(UrlService));
#endregion

#region Configure razor pages
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options => {
        options.Conventions.AddPageRoute("/Index", "");
    });
#endregion
var app = builder.Build();

app.Logger.LogInformation("App created...");

#region Migrations running for identity DB
using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var context = scopedProvider.GetRequiredService<AppIdentityDBContext>();
        if (context.Database.IsSqlServer())
        {
            app.Logger.LogInformation("Database identity migration running...");
            context.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred adding migrations to Database.");
    }
}
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
