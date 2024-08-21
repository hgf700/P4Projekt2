using IdentityService.DataBase;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using P4Projekt2.API.Authorization;
using System.Security.Cryptography;
using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static IdentityModel.OidcConstants;
using Microsoft.EntityFrameworkCore;


namespace IdentityService.Controllers
{
    [ApiController]
    [Route("authorization/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccount authRequest)
        {
            try
            {
                var passwordHash = authRequest.Password; // Powinieneś zaszyfrować hasło przed zapisaniem

                var RegisterUser = new UserRegisterData
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

                await _context.UserRegisterData.AddAsync(RegisterUser);

                // Zapisz zmiany w bazie danych
                await _context.SaveChangesAsync();

                // Generowanie tokenu JWT
                var Registeredtoken = GenerateJwtToken(RegisterUser);

                return Ok(new { Token = Registeredtoken, UserId = RegisterUser.Email });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        private string GenerateJwtToken(UserRegisterData user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("A_very_long_secret_key_that_is_at_least_32_bytes_long");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var tokenString = tokenHandler.WriteToken(token);

                // Tworzenie i zapisywanie instancji Key
                var keyEntry = new Key
                {
                    GuidId = Guid.NewGuid(),
                    AuthorizationKey = tokenString,
                    Expire = DateTime.UtcNow.AddMinutes(30)
                };

                _context.Keys.Add(keyEntry);
                _context.SaveChanges();

                return tokenString;
            }
            catch (Exception ex)
            {
                // Logowanie błędu
                Console.WriteLine($"Error generating JWT token: {ex.Message}"); // Logowanie błędu do konsoli
                return $"Error generating JWT token: {ex.Message}";
            }

        }
        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] LoginAccount loginauthRequest)
        {
            try
            {
                // Szukanie użytkownika na podstawie podanego emaila
                var user = await _context.UserRegisterData
                    .FirstOrDefaultAsync(u => u.Email == loginauthRequest.Email);

                if (user == null)
                {
                    return Unauthorized("Invalid credentials");
                }

                // Weryfikacja hasła (zakładając, że hasło jest przechowywane jako hash)
                var passwordHash = loginauthRequest.Password; // Powinieneś zaszyfrować hasło przed porównaniem

                // Generowanie tokenu JWT
                var Logintoken = GenerateJwtToken(user);

                var keyEntry = await _context.Keys
                           .FirstOrDefaultAsync(k => k.AuthorizationKey == Logintoken);

                // Sprawdzenie, czy Logintoken jest null lub token wygasł
                if (Logintoken == null || keyEntry == null || keyEntry.Expire <= DateTime.UtcNow)
                {
                    return StatusCode(500, "Error while authorizing nedded new generated token");

                    //dokoncz to ooooooooooooo
                }
                else
                {
                    return Ok(new { Token = Logintoken, UserId = user.Email });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

    }
}
