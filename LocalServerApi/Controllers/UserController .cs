using IdentityService.DataBase;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using P4Projekt2.API.Authorization;
using System.Security.Cryptography;
using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IdentityService.ServerData;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("authorization/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly string _jwtSecret;

        public UserController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _jwtSecret = configuration["Jwt:Secret"]; // Pobierz sekret JWT z konfiguracji
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccount authRequest)
        {
            try
            {
                var passwordHash = authRequest.Password; // Powinieneś zaszyfrować hasło przed zapisaniem

                var user = new UserRegisterData
                {
                    ResponseType = authRequest.ResponseType,
                    Firstname = authRequest.Firstname,
                    Lastname = authRequest.Lastname,
                    Email = authRequest.Email,
                    PasswordHash = passwordHash,
                    ClientId = authRequest.ClientId,
                    Scope = authRequest.Scope,
                    State = authRequest.State,
                    RedirectUri = authRequest.RedirectUri,
                    CodeChallenge = authRequest.CodeChallenge,
                    CodeChallengeMethod = authRequest.CodeChallengeMethod,
                };

                //var authorization = new AuthCode
                //{
                //    ClientID = authRequest.ClientId,
                //    RedirectUri = authRequest.RedirectUri,
                //    CodeChallenge = authRequest.CodeChallenge,
                //    CodeChallengeMethod = authRequest.CodeChallengeMethod,
                //    Expiry = DateTime.UtcNow.AddMinutes(10)
                //};

                // Dodajemy użytkownika do kontekstu
                await _context.UserRegisterData.AddAsync(user);

                // Zapisz zmiany w bazie danych
                await _context.SaveChangesAsync();

                // Generowanie tokenu JWT
                var token = GenerateJwtToken(user);

                // Opcjonalnie można też zwrócić jakieś dane użytkownika, np. ID
                return Ok(new { Token = token, UserId = user.ClientId });
            }
            catch (Exception ex)
            {
                // Logowanie błędu
                return StatusCode(500, "Internal server error");
            }
        }

        private string GenerateJwtToken(UserRegisterData user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    // Można dodać więcej claimów w zależności od potrzeby
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
