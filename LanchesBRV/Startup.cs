using LanchesBRV.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesBRV;

public class Startup
{
    // Configuration property to access app settings
    public IConfiguration Configuration { get; }

    // Constructor receives configuration from Program.cs
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Method to register services for dependency injection
    public void ConfigureServices(IServiceCollection services)
    {
        // Registra o AppDbContext como um serviço da aplicação
        services.AddDbContext<AppDbContext>(options =>
        // Configuration.GetConnectionString busca o valor dentro de 'ConnectionStrings' no appsettings.json
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Add MVC controllers and views
        services.AddControllersWithViews();
    }

    // Method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Developer-friendly error page
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Production error handling
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts(); // Enforce HTTPS
        }

        app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
        app.UseStaticFiles();      // Serve static files (wwwroot)

        app.UseRouting();          // Enable endpoint routing

        app.UseAuthorization();    // Authorization middleware

        // Define endpoint mappings
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}