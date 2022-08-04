using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetGroupResponce>> GetGroup(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetGroup получен");

                var result = await _groupService.GetGroupAsync(id);
                var responce = AutoMapperUtility<Group, GetGroupResponce>.Map(result);

                _logger.LogInformation("Запрос GetGroup обработан");

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("byAccount/{id}")]
        public async Task<ActionResult<IEnumerable<GetGroupResponce>>> GetGroupsByAccount(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetGroupsByAccount получен");                

                var result = await _groupService.GetGroupsByAccountAsync(id);
                var responce = new List<GetGroupResponce>();

                foreach (var group in result)
                    responce.Add(AutoMapperUtility<Group, GetGroupResponce>.Map(group));

                _logger.LogInformation("Запрос GetGroupsByAccount обработан");

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateGroupResponce>> CreateGroup([FromBody] CreateGroupRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос CreateGroup получен");

                var group = AutoMapperUtility<CreateGroupRequest, Group>.Map(request);
                var result = await _groupService.CreateGroupAsync(group);
                var responce = AutoMapperUtility<Group, CreateGroupResponce>.Map(result);

                var groupAccount = new GroupAccount() {
                    IsCreator = true,
                    GroupId = result.Id,
                    AccountId = Convert.ToInt32(User.Claims.SingleOrDefault(c => c.Type == "Id").Value)
                };
                await _groupAccountService.CreateGroupAccountAsync(groupAccount);

                _logger.LogInformation("Запрос CreateGroup обработан");

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UpdateGroupResponce>> UpdateGroup([FromBody] UpdateGroupRequest request)
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteGroup получен");

                await _groupService.DeleteGroupAsync(id);
                await _groupAccountService.DeleteAllGroupAccountByGroupAsync(id);

                _logger.LogInformation("Запрос DeleteGroup обработан");

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
