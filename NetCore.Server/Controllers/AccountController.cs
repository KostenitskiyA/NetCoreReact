using Microsoft.AspNetCore.Mvc;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;
using NetCore.Server.Models.Requests;
using NetCore.Server.Models.Responces;
using NetCore.Server.Utilities;

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
        [Route("{id}")]
        public async Task<ActionResult<GetAccountResponce>> GetAccount(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetAccount получен");

                var result = await _accountProvider.GetAccountAsync(id);
                var responce = AutoMapperUtility<Account, GetAccountResponce>.Map(result);
                               
                _logger.LogInformation("Запрос GetAccount обработан");

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("accounts/{id}")]
        public async Task<ActionResult<IEnumerable<GetAccountResponce>>> GetAccountsByGroup(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetAccountsByGroup получен");

                var result = await _accountProvider.GetAccountsByGroupAsync(id);
                var newResult = new List<GetAccountResponce>();

                foreach (var account in result)
                    newResult.Add(AutoMapperUtility<Account, GetAccountResponce>.Map(account));

                _logger.LogInformation("Запрос GetAccountsByGroup обработан");

                return Ok(newResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("updateAvatar")]
        public async Task<ActionResult> UpdateAvatar(UpdateAvatarRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос UpdateAvatar получен");

                await _accountProvider.UpdateAvatarAsync(request.AccountId, request.Avatar);

                _logger.LogInformation("Запрос UpdateAvatar обработан");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }        
    }
}
