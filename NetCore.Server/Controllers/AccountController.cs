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

        /// <summary>
        /// Получение аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns>Аккаунт</returns>
        [HttpGet]
        [Route("{accountId}")]
        public async Task<ActionResult<GetAccountResponce>> GetAccountAsync(int accountId)
        {
            try
            {
                _logger.LogInformation("Запрос GetAccount получен");

                var result = await _accountProvider.GetAccountAsync(accountId);
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

        /// <summary>
        /// Получение друзей аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns>Коллекции друзей аккаунта</returns>
        [HttpGet]
        [Route("{accountId}/friends")]
        public async Task<ActionResult<IEnumerable<GetAccountResponce>>> GetFriendsByAccountAsync(int accountId)
        {
            try
            {
                _logger.LogInformation("Запрос GetAccountFriends получен");

                var result = await _accountProvider.GetFriendsByAccountAsync(accountId);
                var newResult = new List<GetAccountResponce>();

                foreach (var account in result)
                    newResult.Add(AutoMapperUtility<Account, GetAccountResponce>.Map(account));

                _logger.LogInformation("Запрос GetAccountFriends обработан");

                return Ok(newResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получение участников группы
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns>Коллекция участников группы</returns>
        [HttpGet]
        [Route("{groupId}/accounts")]
        public async Task<ActionResult<IEnumerable<GetAccountResponce>>> GetAccountsByGroupAsync(int groupId)
        {
            try
            {
                _logger.LogInformation("Запрос GetAccountsByGroup получен");

                var result = await _accountProvider.GetAccountsByGroupAsync(groupId);
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

        /// <summary>
        /// Поиск аккаунтов по имени
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("searchByName/{searchName}")]
        public async Task<ActionResult<IEnumerable<GetAccountResponce>>> SearchAccountsByNameAsync(string searchName)
        {
            try
            {
                _logger.LogInformation("Запрос SearchAccountsByNameAsync получен");

                var result = await _accountProvider.SearchAccountsByNameAsync(searchName);
                var newResult = new List<GetAccountResponce>();

                foreach (var account in result)
                    newResult.Add(AutoMapperUtility<Account, GetAccountResponce>.Map(account));

                _logger.LogInformation("Запрос SearchAccountsByNameAsync обработан");

                return Ok(newResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Поиск аккаунтов участников группы по имени
        /// </summary>
        /// <param name="groupId">Код группы</param>
        /// <param name="searchName">Имя поиска</param>
        /// <returns>Коллекция найденных участников группы</returns>
        [HttpGet]
        [Route("searchByName/{groupId}/{searchName}")]
        public async Task<ActionResult<IEnumerable<GetAccountResponce>>> SearchAccountsByNameAsync(string groupId, string searchName)
        {
            try
            {
                _logger.LogInformation("Запрос SearchAccountsByNameAsync получен");

                var result = await _accountProvider.SearchAccountsByNameAsync(groupId, searchName);
                var newResult = new List<GetAccountResponce>();

                foreach (var account in result)
                    newResult.Add(AutoMapperUtility<Account, GetAccountResponce>.Map(account));

                _logger.LogInformation("Запрос SearchAccountsByNameAsync обработан");

                return Ok(newResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Обновление аватара
        /// </summary>
        /// <param name="request">Объект изменения аватара</param>
        /// <returns>Результат выполнения</returns>
        [HttpPost]
        [Route("updateAvatar")]
        public async Task<ActionResult> UpdateAvatarAsync([FromBody] UpdateAvatarRequest request)
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
