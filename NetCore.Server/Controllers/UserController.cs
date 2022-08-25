using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;
using NetCore.Server.Models.Configurations;
using NetCore.Server.Models.Requests;
using NetCore.Server.Models.Responces;
using NetCore.Server.Utilities;
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

                var user = AutoMapperUtility<SignInRequest, User>.Map(request);
                var account = AutoMapperUtility<SignInRequest, Account>.Map(request);

                user.Account = account;

                var result = await _userProvider.SignInAsync(user);
                var responce = AutoMapperUtility<Account, SignInResponce>.Map(result);

                _logger.LogInformation("Запрос Signin обработан");


                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LogInResponce>> LogIn([FromBody] LogInRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос Login получен");

                var user = AutoMapperUtility<LogInRequest, User>.Map(request);
                var result = await _userProvider.LogInAsync(user);
                var responce = AutoMapperUtility<Account, LogInResponce>.Map(result);

                /*var authParams = _authOptions.Value;
                var securityKey = authParams.GetSymmetricSecurityKey();
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Name, result.Name) };
                var token = new JwtSecurityToken(
                    issuer: authParams.Issuer,
                    audience: authParams.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                    signingCredentials: credentials);

                var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);*/
                //HttpContext.Response.Cookies.Append("Token", generatedToken);

                /*await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, generatedToken);*/

                HttpContext.Response.Cookies.Append("124214", "214", new CookieOptions() { SameSite = SameSiteMode.None, Domain = "http://localhost:5500", Secure = false });

                var claims = new List<Claim>
                {
                    new Claim("Id", responce.Id.ToString()),
                    new Claim(ClaimTypes.Name, responce.Name)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                _logger.LogInformation("Запрос Login обработан");

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult> LogOut()
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
