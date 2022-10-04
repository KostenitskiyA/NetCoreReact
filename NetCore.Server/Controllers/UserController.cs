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
        private IOptions<JWTAuthenticationOptions> _authenticationOptions;
        private IUserService _userProvider;

        public UserController(ILogger<UserController> logger,
            IOptions<JWTAuthenticationOptions> authenticationOptions,
            IUserService userProvider)
        {
            _logger = logger;
            _authenticationOptions = authenticationOptions;
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

                var authenticationOptions = _authenticationOptions.Value;
                var token = new JwtSecurityToken(
                    issuer: authenticationOptions.Issuer,
                    audience: authenticationOptions.Audience,
                    claims: new List<Claim> { 
                        new Claim("Id", result.Id.ToString()), 
                        new Claim(JwtRegisteredClaimNames.Name, result.Name) 
                    },
                    expires: DateTime.Now.AddSeconds(authenticationOptions.TokenLifetime),
                    signingCredentials: new SigningCredentials(authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

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
