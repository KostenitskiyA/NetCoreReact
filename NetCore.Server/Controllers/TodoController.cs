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
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private ITodoService _todoService;

        public TodoController(ILogger<TodoController> logger,
            ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        [Route("statuses")]
        public async Task<ActionResult<IEnumerable<GetStatusesResponce>>> GetStatuses()
        {
            try
            {
                _logger.LogInformation("Запрос GetStatuses получен");

                var result = await _todoService.GetStatuses();
                var responce = new List<GetStatusesResponce>();

                foreach (var status in result)
                    responce.Add(AutoMapperUtility<TodoStatus, GetStatusesResponce>.Map(status));

                _logger.LogInformation("Запрос GetStatuses обработан");

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetTodoResponce>> GetTodo(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetTodo получен");

                var result = await _todoService.GetTodoAsync(id);
                var responce = AutoMapperUtility<Todo, GetTodoResponce>.Map(result);

                _logger.LogInformation("Запрос GetTodo обработан");

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("byGroup/{id}")]
        public async Task<ActionResult<IEnumerable<GetTodoResponce>>> GetTodosByGroup(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetTodosByGroup получен");

                var result = await _todoService.GetTodosByGroupAsync(id);
                var responce = new List<GetTodoResponce>();

                foreach (var todo in result)
                    responce.Add(AutoMapperUtility<Todo, GetTodoResponce>.Map(todo));


                _logger.LogInformation("Запрос GetTodosByGroup обработан");

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
        public async Task<ActionResult<IEnumerable<GetTodoResponce>>> GetTodosByAccount(int id)
        {
            try
            {
                _logger.LogInformation("Запрос GetTodosByAccount получен");

                var result = await _todoService.GetTodosByAccountAsync(id);
                var responce = new List<GetTodoResponce>();

                foreach (var todo in result)
                    responce.Add(AutoMapperUtility<Todo, GetTodoResponce>.Map(todo));

                _logger.LogInformation("Запрос GetTodosByAccount обработан");

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
        public async Task<ActionResult<CreateTodoResponce>> CreateTodo([FromBody] CreateTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос CreateTodo получен");

                var todo = AutoMapperUtility<CreateTodoRequest, Todo>.Map(request);
                var result = await _todoService.CreteTodoAsync(todo);
                var responce = AutoMapperUtility<Todo, CreateTodoResponce>.Map(result);

                _logger.LogInformation("Запрос CreateTodo обработан");

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
        public async Task<ActionResult<UpdateTodoResponce>> UpdateTodo([FromBody] UpdateTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос UpdateTodo получен");

                var todo = AutoMapperUtility<UpdateTodoRequest, Todo>.Map(request);
                var result = await _todoService.UpdateTodoAsync(todo);
                var responce = AutoMapperUtility<Todo, UpdateTodoResponce>.Map(result);

                _logger.LogInformation("Запрос UpdateTodo обработан");

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
        public async Task<ActionResult> DeleteTodo(int id)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteTodo получен");

                await _todoService.DeleteTodoAsync(id);

                _logger.LogInformation("Запрос DeleteTodo обработан");

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
