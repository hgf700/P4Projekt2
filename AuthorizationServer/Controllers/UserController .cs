using IdentityService.DataBase;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using P4Projekt2.API.Authorization;
using P4Projekt2.API.User;
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
using Newtonsoft.Json;


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
                // Sprawdź, czy użytkownik z tym adresem e-mail już istnieje
                var existingUser = await _context.UserRegisterData
                    .FirstOrDefaultAsync(u => u.Email == authRequest.Email);

                if (existingUser != null)
                {
                    // Zwróć odpowiedź z kodem 409 (Conflict), jeśli użytkownik z tym e-mailem już istnieje
                    return Conflict("User with this email already exists.");
                }

                // Haszowanie hasła
                var hashedPassword = HashPassword(authRequest.Password);

                // Tworzenie nowego użytkownika
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

                // Generowanie tokenu odświeżania
                var refreshtoken = GenerateJwtToken(RegisterUser);

                var Refreshtoken = new RefreshToken
                {
                    Token = refreshtoken,
                    Expiration = DateTime.UtcNow.AddYears(10),
                    IsRevoked = false,
                    UserEmail = RegisterUser.Email // Przypisanie UserEmail do RefreshToken
                };

                await _context.RefreshTokens.AddAsync(Refreshtoken);
                await _context.SaveChangesAsync();

                return new ContentResult
                {
                    Content = JsonConvert.SerializeObject(new { message = "User registered successfully" }),
                    ContentType = "application/json",
                    StatusCode = 200 // OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during registration: {ex.Message}");
                return BadRequest(new { error = ex.Message });
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
                    UserRegisterEmail = user.Email
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

                var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.UserEmail == user.Email);

                if (refreshToken == null || refreshToken.Expiration < DateTime.UtcNow || refreshToken.IsRevoked == true)
                {
                    var newRefreshToken = new RefreshToken
                    {
                        Token = GenerateJwtToken(user),
                        Expiration = DateTime.UtcNow.AddYears(10),
                        IsRevoked = false,
                        UserEmail = user.Email
                    };

                    refreshToken.IsRevoked = true;
                    await _context.RefreshTokens.AddAsync(newRefreshToken);
                    await _context.SaveChangesAsync();
                }

                var existingUser = await _context.UserLoginData.FirstOrDefaultAsync(u => u.Email == loginauthRequest.Email);

                if (existingUser != null)
                {
                    // Jeśli użytkownik już istnieje, możesz zaktualizować dane lub zgłosić błąd
                    return new ContentResult
                    {
                        Content = JsonConvert.SerializeObject(new { message = "User logged successfully" }),
                        ContentType = "application/json",
                        StatusCode = 200 // OK
                    };
                }

                var loginRequest = new UserLoginData
                {
                    ResponseType = loginauthRequest.ResponseType,
                    Email = loginauthRequest.Email,
                    Password = hashedPassword,
                    ClientId = loginauthRequest.ClientId,
                    UserRegisterEmail = user.Email
                };

                await _context.UserLoginData.AddAsync(loginRequest);
                await _context.SaveChangesAsync();

                return Ok(new { Token = loginToken, UserEmail = user.Email });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while login: {ex.Message}");
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPost("message")]
        public async Task<IActionResult> SendMessage([FromBody] UserChatData userchatdata)
        {
            try
            {
                var chatdata = new ChatData
                {
                    Message = userchatdata.Message,
                    SenderEmail = userchatdata.SenderEmail,
                    ReceiverEmail = userchatdata.ReceiverEmail,
                    Timestamp = userchatdata.Timestamp,
                };
                await _context.ChatData.AddAsync(chatdata);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while messaging: {ex.Message}");
                return StatusCode(500, $"{ex.Message}");
            }

        }

        //[HttpPost("addfriend")]
        //public async Task<IActionResult> AddFriend([FromBody] AddToFriendList friendRequest)
        //{
        //    try
        //    {
        //        // Check if a friend request already exists
        //        //var existingRequest = await _context.FriendList
        //        //    .FirstOrDefaultAsync(f => f.RequesterEmail == friendRequest.RequesterEmail && f.FriendEmail == friendRequest.FriendEmail);

        //        //if (existingRequest != null)
        //        //{
        //        //    return Conflict("Friend request already exists.");
        //        //}

        //        var addfriend = new AddToFriendList
        //        {

        //        };

        //        // Set default values
        //        friendRequest.RequestedAt = DateTime.UtcNow;
        //        friendRequest.IsAccepted = false; // Initially, the request is not accepted

        //        await _context.FriendList.AddAsync(friendRequest);
        //        await _context.SaveChangesAsync();

        //        return Ok("Friend request sent.");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error while adding friend: {ex.Message}");
        //        return StatusCode(500, "Internal server error.");
        //    }
        //}







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
