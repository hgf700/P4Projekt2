using IdentityService.DataBase;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using P4Projekt2.API.Authorization;
using System.Security.Cryptography;
using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using static IdentityModel.OidcConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


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
                var hashedPassword = HashPassword(authRequest.Password);

                var RegisterUser = new UserRegisterData
                {
                    ResponseType = authRequest.ResponseType,
                    Firstname = authRequest.Firstname,
                    Lastname = authRequest.Lastname,
                    Email = authRequest.Email,
                    PasswordHash = hashedPassword,
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
                    Expire = DateTime.UtcNow.AddMinutes(30),
                    UserRegisterDataId = user.IdRegister
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
                var user = await _context.UserRegisterData.FirstOrDefaultAsync(u => u.Email == loginauthRequest.Email);
                if (user == null)
                {
                    return Unauthorized("User does not exist.");
                }

                var hashedPassword = HashPassword(loginauthRequest.PasswordHash); // Hashuj hasło podane przez użytkownika

                // Porównaj z hashem zapisanym w bazie
                if (hashedPassword != user.PasswordHash)
                {
                    return Unauthorized("Invalid credentials.");
                }

                var loginToken = GenerateJwtToken(user);

                var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.UserId == user.IdRegister);

                if (refreshToken != null && refreshToken.Expiration > DateTime.UtcNow && !refreshToken.IsRevoked)
                {
                    var newRefreshToken = new RefreshToken
                    {
                        Token = GenerateJwtToken(user),
                        Expiration = DateTime.UtcNow.AddYears(10),
                        IsRevoked = false,
                        UserId = user.IdRegister
                    };

                    refreshToken.IsRevoked = true;
                    await _context.RefreshTokens.AddAsync(newRefreshToken);
                    await _context.SaveChangesAsync();
                }

                var loginRequest = new UserLoginData
                {
                    ResponseType = loginauthRequest.ResponseType,
                    Email = loginauthRequest.Email,
                    Password = hashedPassword,
                    ClientId = loginauthRequest.ClientId,
                    UserRegisterDataId = user.IdRegister
                };

                await _context.UserLoginData.AddAsync(loginRequest);
                await _context.SaveChangesAsync();

                return Ok(new { Token = loginToken, UserId = user.Email });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while login: {ex.Message}");
                return StatusCode(500, $"{ex.Message}");
            }
        }









        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }




    }
}
