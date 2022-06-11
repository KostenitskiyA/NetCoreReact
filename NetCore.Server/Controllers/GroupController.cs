using Microsoft.AspNetCore.Mvc;
using NetCore.Server.Interfaces;
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

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateGroupResponce>> CreateGroup([FromBody] CreateGroupRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос Signin получен");

                ///var result = 

                _logger.LogInformation("Запрос Signin обработан");

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
