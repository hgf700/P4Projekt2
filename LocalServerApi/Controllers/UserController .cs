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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;


namespace IdentityService.Controllers
{
    [ApiController]
    [Route("authorization/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserController> _logger;
        public UserController(ApplicationDbContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
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
                await _context.SaveChangesAsync();

                var refreshtoken = GenerateJwtToken(RegisterUser);

                var Refreshtoken = new RefreshToken
                {
                    Token = refreshtoken,
                    Expiration = DateTime.UtcNow.AddYears(10),
                    IsRevoked = false,
                    UserId = RegisterUser.IdRegister // Przypisanie UserId do RefreshToken
                };

                await _context.RefreshTokens.AddAsync(Refreshtoken);
                await _context.SaveChangesAsync();

                // Generowanie tokenu JWT
                var Registeredtoken = GenerateJwtToken(RegisterUser);

                return Ok(new { Token = Registeredtoken, UserId = RegisterUser.Email });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while register: {ex.Message}");
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
                var user = await _context.UserRegisterData.FirstOrDefaultAsync(u => u.Email == loginauthRequest.Email);

                if (user == null)
                {
                    return Unauthorized("Invalid credentials");
                }

                // Weryfikacja hasła
                var passwordHasher = new PasswordHasher<UserRegisterData>();
                var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginauthRequest.PasswordHash);

                if (verificationResult == PasswordVerificationResult.Failed || user.Email != loginauthRequest.Email)
                {
                    return Unauthorized("Invalid credentials");
                }

                // Generowanie tokenu JWT
                var Logintoken = GenerateJwtToken(user);

                var keyEntry = await _context.Keys.FirstOrDefaultAsync(k => k.AuthorizationKey == Logintoken);

                // Sprawdzenie, czy Logintoken jest null lub token wygasł
                if (keyEntry == null || keyEntry.Expire <= DateTime.UtcNow)
                {
                    // Możesz wygenerować nowy token i go zwrócić
                    var newLogintoken = GenerateJwtToken(user);





                    return Ok(new { Token = newLogintoken, UserId = user.Email });
                }
                else
                {
                    // Zwróć istniejący token, jeśli jest nadal ważny
                    return Ok(new { Token = Logintoken, UserId = user.Email });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while login: {ex.Message}");
                return StatusCode(500, $"{ex.Message}");
            }
        }


        [HttpPost("authorizeaccess")]
        public async Task<IActionResult> RefreshTokeCheck([FromBody] RefreshToken refreshToken)
        {
            try
            {
                // Znajdź token w bazie danych
                var storedToken = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);
                var user = await _context.UserRegisterData.FirstOrDefaultAsync(u => u.IdRegister == storedToken.UserId);

                if (user == null)
                {
                    return Unauthorized("User not found");
                }

                // Sprawdzenie stanu tokena
                if (storedToken.Expiration > DateTime.UtcNow && !storedToken.IsRevoked)
                {
                    // Wygenerowanie nowego tokenu JWT
                    var newJwtToken = GenerateJwtToken(user);

                    // Opcjonalnie: można również odświeżyć token odświeżający
                    var newRefreshToken = new RefreshToken
                    {
                        Token = GenerateJwtToken(user), // lub inna metoda generowania unikalnego tokena odświeżającego
                        Expiration = DateTime.UtcNow.AddYears(10), // np. 10 lat
                        IsRevoked = false,
                        UserId = user.IdRegister
                    };

                    // Cofnięcie starego tokena odświeżającego
                    storedToken.IsRevoked = true;

                    // Dodaj nowy token odświeżający do bazy danych
                    await _context.RefreshTokens.AddAsync(newRefreshToken);

                    // Zapisz zmiany w bazie danych
                    await _context.SaveChangesAsync();

                    return Ok(new { Token = newJwtToken, RefreshToken = newRefreshToken.Token, Message = "Generated new token, try to log in again" });
                }
                else if (storedToken.Expiration < DateTime.UtcNow && !storedToken.IsRevoked && user != null)
                {
                    // Autoryzacja zakończona sukcesem
                    return Ok("Authorization success");
                }
                else
                {
                    return Unauthorized("Something went wrong while authorizing");
                }
            }
            catch(Exception ex)
            {
                // Logowanie błędu
                _logger.LogError(ex, $"Error while authorization: {ex.Message}");

                // Zwracanie ogólnego komunikatu o błędzie
                return StatusCode(500, "An error occurred while processing your request");
            }
            
        }


    }
}
