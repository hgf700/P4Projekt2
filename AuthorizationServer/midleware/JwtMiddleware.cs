using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;



namespace IdentityService.midleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;

        }

        public async Task Invoke(HttpContext context, ApplicationDbContext _context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, token, _context);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token, ApplicationDbContext _context)
        {
            try
            {
                // Walidacja tokenu oraz przypisanie użytkownika do kontekstu
                var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

                // Pobieranie użytkownika z bazy danych na podstawie userId
                var user = _context.UserRegisterData.SingleOrDefault(u => u.IdRegister.ToString() == userId);

                // Przypisanie użytkownika do kontekstu, jeśli token jest poprawny
                context.Items["User"] = user;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Błąd podczas weryfikacji tokenu lub dostępu do bazy danych: {ex.Message}");
            }
        }
    }
}
