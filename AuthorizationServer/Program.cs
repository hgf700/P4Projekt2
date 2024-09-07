using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IdentityService.midleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;


public class Program
{
    public static void Main(string[] args)
    {
#if DEVELOPMENT
        MainDevelopment(args);
#else
        MainProduction(args);
#endif
    }

    private static void MainProduction(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Konfiguracja po³¹czenia z PostgreSQL
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Konfiguracja pozosta³ych us³ug
        builder.Services.AddControllersWithViews();

        var key = Encoding.ASCII.GetBytes("SecretKey");

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

        // Dodanie Swagger (jeœli potrzebujesz dokumentacji API)
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Konfiguracja aplikacji - kolejnoœæ ma znaczenie!
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication(); // Dodaj middleware uwierzytelniania
        app.UseMiddleware<JwtMiddleware>(); // Dodaj custom middleware do obs³ugi JWT
        app.UseAuthorization();  // Dodaj middleware autoryzacji

        app.MapControllers();

        // Konfiguracja middleware
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static void MainDevelopment(string[] args)
    {
        Console.WriteLine("Running in development mode...");
        MainProduction(args); // Mo¿esz u¿yæ tej samej konfiguracji, co w produkcji
    }
}
