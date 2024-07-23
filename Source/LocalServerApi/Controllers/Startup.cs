using Microsoft.EntityFrameworkCore;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Konfiguracja połączenia z PostgreSQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

        services.AddControllersWithViews();
    }

    //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //{
    //    // Inna konfiguracja aplikacji
    //}
}
