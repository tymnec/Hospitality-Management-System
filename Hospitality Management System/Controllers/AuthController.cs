using HospitalityManagementSystem.Models;
using HospitalityManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace HospitalityManagementSystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _config;

        public AuthController(UserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user, string password)
        {
            var success = await _userService.RegisterAsync(user, password);
            if (!success) return BadRequest("Email already exists.");
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.AuthenticateAsync(request.Email, request.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        // Get Settings: Get the settings of the currently authenticated user
        [HttpGet("settings")]
        public async Task<IActionResult> GetSettings()
        {
            // Extract the JWT token from the Authorization header
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token is missing.");

            var userId = GetUserIdFromToken(token);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User not authenticated.");

            // Fetch user from the database
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            // Assuming that 'user.Settings' contains the user's settings or preferences
            return Ok(user);  // Return the user's settings
        }


        // Update User Settings: Update the settings of the currently authenticated user
        [HttpPut("settings")]
        public async Task<IActionResult> UpdateSettings([FromBody] User user)
        {
            // Extract the JWT token from the Authorization header
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token is missing.");

            var userId = GetUserIdFromToken(token);
            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine(token, userId);
                return Unauthorized("User not authenticated.");
            }

            // Fetch user from the database
            var existingUser = await _userService.GetUserByIdAsync(userId);
            if (existingUser == null)
                return NotFound("User not found.");

            // Validate all the fields
            if (string.IsNullOrWhiteSpace(user.Username))
                return BadRequest("Username is required.");

            if (string.IsNullOrWhiteSpace(user.Email))
                return BadRequest("Email is required.");

            if (string.IsNullOrWhiteSpace(user.Role))
                return BadRequest("Role is required.");

            // Update the user's settings
            user.Id = existingUser.Id;
            var success = await _userService.UpdateUserAsync(user);
            if (!success) return BadRequest("Failed to update user settings.");

            return Ok("User settings updated successfully");
        }

        // Helper function to extract user ID from JWT token
        private string? GetUserIdFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null) return null;

            var userIdClaim = jwtToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
