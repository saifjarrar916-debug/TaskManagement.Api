using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TaskManagement.Api.Data;
using TaskManagement.Api.Dto;
using TaskManagement.Api.Models;
using TaskManagement.Api.Utility;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApiResponse _response;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this._configuration = configuration;
            _response = new ApiResponse();
        }

        [HttpPost("register")]

        public async Task <IActionResult> Register([FromBody] RegisterDto  model)
        {
            var existinguser =  await _userManager.FindByEmailAsync(model.Email);
            if (existinguser != null)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Errors.Add("user is already exist");
                return BadRequest(_response);
            }
            var user = new AppUser {UserName=model.Email,Email=model.Email };
            var result = await _userManager.CreateAsync(user, model.password);
            if (!result.Succeeded)
            {
                _response.Status = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Errors.AddRange(
                    result.Errors.Select(e => e.Description)
                );

                return BadRequest(_response);
                
            }
            if (!await _roleManager.RoleExistsAsync(SD.Role_Customer))
            {
                await _roleManager.CreateAsync(
                    new IdentityRole(SD.Role_Customer)
                );
            }

            var roleResult = await _userManager.AddToRoleAsync(
                user,
                SD.Role_Customer
            );
            _response.Status = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = new
            {
                message = "Account created successfully"
            };

            return Ok(_response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequestDto model)
        {
            var response = new ApiResponse();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null ||
                !await _userManager.CheckPasswordAsync(
                    user,
                    model.password))
            {
                response.Status = HttpStatusCode.Unauthorized;
                response.IsSuccess = false;
                response.Errors.Add("Invalid email or password");

                return Unauthorized(response);
            }

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(
                    ClaimTypes.Name,
                    user.UserName ?? user.Email ?? ""
                ),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = _configuration["Jwt:Key"]!;
            var issuer = _configuration["Jwt:Issuer"]!;
            var audience = _configuration["Jwt:Audience"]!;

            var expiryMinutes = int.Parse(
                _configuration["Jwt:ExpiryMinutes"] ?? "60"
            );

            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key)
            );

            var credentials = new SigningCredentials(
                signingKey,
                SecurityAlgorithms.HmacSha256
            );

            var expiresAt = DateTime.UtcNow.AddMinutes(expiryMinutes);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials
            );

            var loginResponse = new LoginResponseDto
            {
                Email = user.Email ?? "",
                Token = new JwtSecurityTokenHandler()
                    .WriteToken(token),
                Role = roles.FirstOrDefault() ?? "",
                ExpiersAt = expiresAt
            };

            response.Status = HttpStatusCode.OK;
            response.IsSuccess = true;
            response.Result = loginResponse;

            return Ok(response);
        }
    }
}
