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
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private IGroupService _groupService;
        private IGroupAccountService _groupAccountService;

        public GroupController(ILogger<GroupController> logger,
            IGroupService groupService,
            IGroupAccountService groupAccountService)
        {
            _logger = logger;
            _groupService = groupService;
            _groupAccountService = groupAccountService;
        }

        /// <summary>
        /// Получение группы
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns>Группа</returns>
        [HttpGet]
        [Route("{groupId}")]
        public async Task<ActionResult<GetGroupResponce>> GetGroupAsync(int groupId)
        {
            try
            {
                _logger.LogInformation("Запрос GetGroup получен");

                var result = await _groupService.GetGroupAsync(groupId);
                var responce = AutoMapperUtility<Group, GetGroupResponce>.Map(result);

                _logger.LogInformation("Запрос GetGroup обработан");

                return Ok(responce);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Получение групп аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns>Коллекция групп аккаунта</returns>
        [HttpGet]
        [Route("{accountId}/groups")]
        public async Task<ActionResult<IEnumerable<GetGroupResponce>>> GetGroupsByAccountAsync(int accountId)
        {
            try
            {
                _logger.LogInformation("Запрос GetGroupsByAccountAsync получен");                

                var result = await _groupService.GetGroupsByAccountAsync(accountId);
                var responce = new List<GetGroupResponce>();

                foreach (var group in result)
                    responce.Add(AutoMapperUtility<Group, GetGroupResponce>.Map(group));

                _logger.LogInformation("Запрос GetGroupsByAccountAsync обработан");

                return Ok(responce);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Создание группы
        /// </summary>
        /// <param name="request">Запрос создания группы</param>
        /// <returns>Созданная группа</returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateGroupResponse>> CreateGroupAsync([FromBody] CreateGroupRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос CreateGroup получен");

                var group = AutoMapperUtility<CreateGroupRequest, Group>.Map(request);
                var result = await _groupService.CreateGroupAsync(group);
                var responce = AutoMapperUtility<Group, CreateGroupResponse>.Map(result);

                var groupAccount = new GroupAccount() {
                    IsCreator = true,
                    GroupId = result.Id,
                    AccountId = Convert.ToInt32(User.Claims.SingleOrDefault(c => c.Type == "Id").Value)
                };
                await _groupAccountService.CreateGroupAccountAsync(groupAccount);

                _logger.LogInformation("Запрос CreateGroup обработан");

                return Ok(responce);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }
        
        /// <summary>
        /// Обновление группы
        /// </summary>
        /// <param name="request">Запрос обновления группы</param>
        /// <returns>Обновленная группа</returns>
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UpdateGroupResponce>> UpdateGroupAsync([FromBody] UpdateGroupRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос UpdateGroup получен");

                var group = AutoMapperUtility<UpdateGroupRequest, Group>.Map(request);                               
                var result = await _groupService.UpdateGroupAsync(group);
                var responce = AutoMapperUtility<Group, UpdateGroupResponce>.Map(result);

                _logger.LogInformation("Запрос UpdateGroup обработан");

                return Ok(responce);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns>Результат выполнения</returns>
        [HttpPost]
        [Route("{groupId}/delete")]
        public async Task<ActionResult> DeleteGroupAsync(int groupId)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteGroup получен");

                await _groupService.DeleteGroupAsync(groupId);
                await _groupAccountService.DeleteAllGroupAccountByGroupAsync(groupId);

                _logger.LogInformation("Запрос DeleteGroup обработан");

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }
    }
}
