using Serilog;
using UrlShortener.Web.Interfaces;
using UrlShortener.Web.Services;

var builder = WebApplication.CreateBuilder(args);


#region Configure Serilog
var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
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
