using Microsoft.AspNetCore.Mvc;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private IAccountService _accountProvider;

        public AccountController(ILogger<AccountController> logger,
            IAccountService accountProvider)
        {
            _logger = logger;
            _accountProvider = accountProvider;
        }

        [HttpGet]
        [Route("account/{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetAccount получен");

                var result = await _accountProvider.GetAccountAsync(id);

                _logger.LogInformation("Запрос GetAccount обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("accounts/{id}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountsByGroup(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetAccountsByGroup получен");

                var result = await _accountProvider.GetAccountsByGroupAsync(id);

                _logger.LogInformation("Запрос GetAccountsByGroup обработан");

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
