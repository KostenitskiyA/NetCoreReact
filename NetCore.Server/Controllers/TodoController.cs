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
        private ITodoService _todoProvider;

        public TodoController(ILogger<TodoController> logger,
            ITodoService todoProvider)
        {
            _logger = logger;
            _todoProvider = todoProvider;
        }

        [HttpGet]
        [Route("statuses")]
        public async Task<ActionResult<IEnumerable<Todo>>> GetStatuses()
        {
            try
            {
                _logger.LogInformation("Запрос GetStatuses получен");

                var result = await _todoProvider.GetStatuses();

                _logger.LogInformation("Запрос GetStatuses обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            try
            {
                _logger.LogInformation("Запрос Todo получен");

                var result = await _todoProvider.GetTodoAsync(id);

                _logger.LogInformation("Запрос Todo обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("byGroup/{id}")]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodosByGroup(int id)
        {
            try
            {
                _logger.LogInformation("Запрос Todos получен");

                var result = await _todoProvider.GetTodosByGroupAsync(id);

                _logger.LogInformation("Запрос Todos обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("byAccount/{id}")]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodosByAccount(int id)
        {
            try
            {
                _logger.LogInformation("Запрос Todos получен");

                var result = await _todoProvider.GetTodosByAccountAsync(id);

                _logger.LogInformation("Запрос Todos обработан");

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
        public async Task<ActionResult<CreateTodoResponce>> CreateTodo([FromBody] CreateTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос CreateTodo получен");

                var todo = AutoMapperUtility<CreateTodoRequest, Todo>.Map(request);

                var result = await _todoProvider.CreteTodoAsync(todo);

                var todoResponce = AutoMapperUtility<Todo, CreateTodoResponce>.Map(result);

                _logger.LogInformation("Запрос CreateTodo обработан");

                return Ok(todoResponce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("edit")]
        public async Task<ActionResult<UpdateTodoResponce>> UpdateTodo([FromBody] UpdateTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос EditTodo получен");

                var todo = AutoMapperUtility<UpdateTodoRequest, Todo>.Map(request);

                var result = await _todoProvider.UpdateTodoAsync(todo);

                var responce = AutoMapperUtility<Todo, UpdateTodoResponce>.Map(result);

                _logger.LogInformation("Запрос EditTodo обработан");

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

                await _todoProvider.DeleteTodoAsync(id);

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
