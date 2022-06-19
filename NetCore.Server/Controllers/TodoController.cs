using Microsoft.AspNetCore.Mvc;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

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
        public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
        {
            try
            {
                _logger.LogInformation("Запрос CreateTodo получен");

                var createdTodo = new Todo()
                {
                    Id = 0,
                    Title = todo.Title,
                    Description = todo.Description,
                    StatusId = todo.StatusId,
                    CreateDate = DateTime.Now,
                    ChangeDate = DateTime.Now,
                };
                var result = await _todoProvider.CreteTodoAsync(createdTodo);

                _logger.LogInformation("Запрос CreateTodo обработан");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("edit")]
        public async Task<ActionResult<Todo>> UpdateTodo(Todo todo)
        {
            try
            {
                _logger.LogInformation("Запрос EditTodo получен");

                var result = await _todoProvider.UpdateTodoAsync(todo);

                _logger.LogInformation("Запрос EditTodo обработан");

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
