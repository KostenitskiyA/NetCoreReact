using AutoMapper;
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

                // Маппим CreateGroupRequest в Group
                var configCreateGroupRequest = new MapperConfiguration(cfg => cfg.CreateMap<CreateGroupRequest, Group>());
                var mapperCreateGroupRequest = configCreateGroupRequest.CreateMapper();
                var userRequest = mapperCreateGroupRequest.Map<Group>(request);

                var result = await _groupService.CreateGroupAsync(
                    new Group() { 
                        Name = request.Name, 
                        Code = request.Code, 
                        OwnerId = request.OwnerId 
                    });

                // Маппим CreateGroupResponce в Group
                var configCreateGroupResponce = new MapperConfiguration(cfg => cfg.CreateMap<CreateGroupResponce, Group>());
                var mapperCreateGroupResponce = configCreateGroupResponce.CreateMapper();
                var userResponce = mapperCreateGroupResponce.Map<CreateGroupResponce>(result);

                _logger.LogInformation("Запрос CreateGroup обработан");

                return Ok(userResponce);
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

                // Маппим UpdateGroupRequest в Group
                var configUpdateGroupRequest = new MapperConfiguration(cfg => cfg.CreateMap<UpdateGroupRequest, Group>());
                var mapperUpdateGroupRequest = configUpdateGroupRequest.CreateMapper();
                var userRequest = mapperUpdateGroupRequest.Map<Group>(request);


                var result = await _groupService.UpdateGroupAsync(new Group());

                // Маппим UpdateGroupResponce в Group
                var configUpdateGroupResponce = new MapperConfiguration(cfg => cfg.CreateMap<UpdateGroupResponce, Group>());
                var mapperUpdateGroupResponce = configUpdateGroupResponce.CreateMapper();
                var userResponce = mapperUpdateGroupResponce.Map<UpdateGroupResponce>(result);

                _logger.LogInformation("Запрос Signin обработан");

                return Ok(userResponce);
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
