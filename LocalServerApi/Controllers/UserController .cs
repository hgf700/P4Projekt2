using IdentityService.DataBase;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using P4Projekt2.API.Authorization;
using System.Security.Cryptography;
using System.Linq;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterAccount authRequest)
        {
            //if (_context.usersaveddata.Any(u => u.Email == authRequest.Email))
            //{
            //    return BadRequest("User can only create one account per email");
            //}

            var passwordHash = HashPassword(authRequest.Password);
            var user = new UserRegisterData
            {
                Granttype = authRequest.Granttype,
                Firstname = authRequest.Firstname,
                Lastname = authRequest.Lastname,
                Email = authRequest.Email,
                PasswordHash = passwordHash,
                ClientId = authRequest.ClientId
            };

            _context.UserRegisterData.Add(user);
            _context.SaveChanges();

            var token = GenerateToken(authRequest);

            return Ok(new { Token = token });
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] RegisterAccount authRequest)
        {
            var user = _context.UserRegisterData.FirstOrDefault(u => u.Email == authRequest.Email);
            if (user == null || !VerifyPassword(authRequest.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = GenerateToken(authRequest);

            return Ok(new { Token = token });
        }

        private string GenerateToken(RegisterAccount authRequest)
        {
            // Przykładowa metoda generowania tokenu (JWT lub innego rodzaju)
            return $"fake-jwt-token-for-{authRequest.Email}";
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            if (parts.Length != 2)
            {
                return false;
            }

            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hash == parts[1];
        }

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] RegisterAccount authRequest)
        //{
            
        //}
    }
}
