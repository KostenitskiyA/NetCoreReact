using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;
using System.Security.Claims;

namespace NetCore.Server.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _authenticationProvider;

        public UserController(ILogger<UserController> logger, 
            IUserService authenticationProvider)
        {
            _logger = logger;
            _authenticationProvider = authenticationProvider;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult<Account>> Signin([FromBody] Account user)
        {
            try
            {
                _logger.LogInformation("Запрос Signin получен");

                var result = await _authenticationProvider.SignInAsync(user);

                _logger.LogInformation("Запрос Signin обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Account>> Login([FromBody] Account user)
        {
            try
            {
                _logger.LogInformation("Запрос Login получен");

                var result = await _authenticationProvider.LogInAsync(user);

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, result.Name) };

                /*var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                new JwtSecurityTokenHandler().WriteToken(jwt);*/

                HttpContext.Response.Cookies.Append("Mister", "Bebra", new CookieOptions() { Secure = false, HttpOnly = false });

                _logger.LogInformation("Запрос Login обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.InnerException + ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult> Logout([FromBody] Account user)
        {
            try
            {
                _logger.LogInformation("Запрос Logout получен");

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                _logger.LogInformation("Запрос Logout обработан");

                return Redirect("");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
