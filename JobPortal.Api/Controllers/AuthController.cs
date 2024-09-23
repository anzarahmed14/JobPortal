using JobPortal.DTO;
using JobPortal.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService  _jwtService;

        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponseDTO>> Login([FromBody] UserLoginRequestDTO request)
        {
            var user = await _authService.AuthenticateAsync(request.EmailAddress, request.Password);
            if (user == null)
            {
                return BadRequest("Invalid username or password.");
            }


            // Generate tokens for the authenticated user
            var (accessToken, refreshToken) = _jwtService.GenerateTokens(user.EmailAddress);


            // Generate and return JWT token
            // Example: return Ok(new { Token = GenerateJwtToken(user) });
            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserInfo = new
                {
                    user.Id,
                    user.EmailAddress,
                    user.Role
                    // Include other user info fields as needed
                }
            });
        }
    }
}
