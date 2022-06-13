using Microsoft.AspNetCore.Mvc;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;
using NetCore.Server.Models.Requests;
using NetCore.Server.Models.Responces;

namespace NetCore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private IGroupService _groupService;

        public GroupController(ILogger<GroupController> logger,
            IGroupService groupService)
        {
            _logger = logger;
            _groupService = groupService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetGroupResponce>> GetGroup(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetGroup получен");

                var result = await _groupService.GetGroupAsync(id);

                _logger.LogInformation("Запрос GetGroup обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("groups/{id}")]
        public async Task<ActionResult<GetGroupsResponce>> GetGroupsByAccount(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetGroupsByAccount получен");

                var result = await _groupService.GetGroupsByAccountAsync(id);

                _logger.LogInformation("Запрос GetGroupsByAccount обработан");

                return Ok(result);
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

                var result = await _groupService.CreateGroupAsync(
                    new Group() { 
                        Name = request.Name, 
                        Code = request.Code, 
                        OwnerId = request.OwnerId 
                    });

                _logger.LogInformation("Запрос CreateGroup обработан");

                return Ok(result);
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
                _logger.LogInformation("Запрос Signin получен");

                var result = await _groupService.UpdateGroupAsync(new Group());

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
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteGroup получен");

                await _groupService.DeleteGroupAsync(id);

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
