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

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="request">Запрос регистрации пользователя</param>
        /// <returns>Авторизированный пользователь</returns>
        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult<SignInResponce>> SignInAsync([FromBody] SignInRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос SignInAsync получен");

                var user = AutoMapperUtility<SignInRequest, User>.Map(request);
                var account = AutoMapperUtility<SignInRequest, Account>.Map(request);

                user.Account = account;

                var result = await _userProvider.SignInAsync(user);
                var responce = AutoMapperUtility<Account, SignInResponce>.Map(result);

                _logger.LogInformation("Запрос SignInAsync обработан");


                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="request">Запрос авторизации пользователя</param>
        /// <returns>Авторизированный пользователь</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LogInResponce>> LogInAsync([FromBody] LogInRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос LogInAsync получен");

                var user = AutoMapperUtility<LogInRequest, User>.Map(request);
                var result = await _userProvider.LogInAsync(user);
                var responce = AutoMapperUtility<Account, LogInResponce>.Map(result);

                var authParams = _authOptions.Value;
                var securityKey = authParams.GetSymmetricSecurityKey();
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim> { new Claim("Id", result.Id.ToString()), new Claim(JwtRegisteredClaimNames.Name, result.Name) };
                var token = new JwtSecurityToken(
                    issuer: authParams.Issuer,
                    audience: authParams.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                    signingCredentials: credentials);

                var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

                responce.Token = generatedToken;

                _logger.LogInformation("Запрос LogInAsync обработан");

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Деавторизация пользователя
        /// </summary>
        /// <returns>Результат выполнения</returns>
        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult> LogOutAsync()
        {
            try
            {
                _logger.LogInformation("Запрос LogOutAsync получен");

               await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                _logger.LogInformation("Запрос LogOutAsync обработан");

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
