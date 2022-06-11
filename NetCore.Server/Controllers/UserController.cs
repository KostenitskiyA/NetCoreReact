using Microsoft.AspNetCore.Mvc;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IAccountService _userProvider;

        public UserController(ILogger<UserController> logger,
            IAccountService userProvider)
        {
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<ActionResult<Account>> GetUser(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetUser получен");

                var result = await _userProvider.GetUserAsync(id);

                _logger.LogInformation("Запрос GetUser обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<Account>>> GetUsers()
        {
            try
            {
                _logger.LogInformation("Запрос GetUsers получен");

                var result = await _userProvider.GetUsersAsync();

                _logger.LogInformation("Запрос GetUsers обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
