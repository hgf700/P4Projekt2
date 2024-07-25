using IdentityService.DataBase;
using Microsoft.AspNetCore.Mvc;
using P4Projekt2.API.Authorization;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<UserSavedData> userssaved = new List<UserSavedData>();
        [HttpPost("register")]
        public async Task<IActionResult> Authenticate([FromBody] AuthTokenRequest authRequest)
        {
            var user = userssaved.FirstOrDefault(u => u.Email == authRequest.Email && u.Password == authRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }
            if (userssaved.Any(u => u.Email == authRequest.Email))
            {
                return BadRequest("User can only create one account per email");
            }

            // Tu możesz dodać logikę generowania tokenu JWT
            var token = GenerateToken(authRequest);

            await Task.CompletedTask;

            return Ok(new { Token = token });
        }

        private string GenerateToken(AuthTokenRequest authRequest)
        {
            // Przykładowa metoda generowania tokenu (JWT lub innego rodzaju)
            return $"fake-jwt-token-for-{authRequest.Email}";
        }
    }
}
