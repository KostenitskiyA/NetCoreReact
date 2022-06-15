using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;
using NetCore.Server.Models.Configure;
using NetCore.Server.Models.Requests;
using NetCore.Server.Models.Responces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NetCore.Server.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IOptions<AuthOptions> _authOptions;
        private IUserService _userProvider;

        public UserController(ILogger<UserController> logger, 
            IOptions<AuthOptions> authOptions,
            IUserService userProvider)
        {
            _logger = logger;
            _authOptions = authOptions;
            _userProvider = userProvider;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult<SignInResponce>> SignIn([FromBody] SignInRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос Signin получен");

                var result = await _userProvider.SignInAsync(new Models.User());

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
        public async Task<ActionResult<Account>> LogIn([FromBody] User user)
        {
            try
            {
                _logger.LogInformation("Запрос Login получен");

                var result = await _userProvider.LogInAsync(user);

                var authParams = _authOptions.Value;
                var securityKey = authParams.GetSymmetricSecurityKey();
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim> { 
                    new Claim(JwtRegisteredClaimNames.Name, result.Name)
                };

                var token = new JwtSecurityToken(
                    issuer: authParams.Issuer,
                    audience: authParams.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                    signingCredentials: credentials);

                var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

                HttpContext.Response.Cookies.Append("Token", generatedToken);

                _logger.LogInformation("Запрос Login обработан");

                result.User = null;

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
        public async Task<ActionResult> LogOut([FromBody] Account user)
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
