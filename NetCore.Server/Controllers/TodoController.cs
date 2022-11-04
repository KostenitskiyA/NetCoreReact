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

        /// <summary>
        /// Получение статусов
        /// </summary>
        /// <returns>Коллекция статусов</returns>
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
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <param name="todoId">Идентификатор задачи</param>
        /// <returns>Задача</returns>
        [HttpGet]
        [Route("{todoId}")]
        public async Task<ActionResult<GetTodoResponce>> GetTodoAsync(int todoId)
        {
            try
            {
                _logger.LogInformation("Запрос GetTodoAsync получен");

                var result = await _todoService.GetTodoAsync(todoId);
                var responce = AutoMapperUtility<Todo, GetTodoResponce>.Map(result);

                _logger.LogInformation("Запрос GetTodoAsync обработан");

                return Ok(responce);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Получение задач аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns>Коллекция задач аккаунта</returns>
        [HttpGet]
        [Route("account:{accountId}/todos")]
        public async Task<ActionResult<IEnumerable<GetTodoResponce>>> GetTodosByAccountAsync(int accountId)
        {
            try
            {
                _logger.LogInformation("Запрос GetTodosByAccountAsync получен");

                var result = await _todoService.GetTodosByAccountAsync(accountId);
                var responce = new List<GetTodoResponce>();

                foreach (var todo in result)
                    responce.Add(AutoMapperUtility<Todo, GetTodoResponce>.Map(todo));

                _logger.LogInformation("Запрос GetTodosByAccountAsync обработан");

                return Ok(responce);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Получение задач группы
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns>Коллекция задач группы</returns>
        [HttpGet]
        [Route("group:{groupId}/todos")]
        public async Task<ActionResult<IEnumerable<GetTodoResponce>>> GetTodosByGroupAsync(int groupId)
        {
            try
            {
                _logger.LogInformation("Запрос GetTodosByGroupAsync получен");

                var result = await _todoService.GetTodosByGroupAsync(groupId);
                var responce = new List<GetTodoResponce>();

                foreach (var todo in result)
                    responce.Add(AutoMapperUtility<Todo, GetTodoResponce>.Map(todo));


                _logger.LogInformation("Запрос GetTodosByGroupAsync обработан");

                return Ok(responce);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="request">Запрос создания задачи</param>
        /// <returns>Созданная задача</returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateTodoResponce>> CreateTodoAsync([FromBody] CreateTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос CreateTodoAsync получен");

                var todo = AutoMapperUtility<CreateTodoRequest, Todo>.Map(request);
                var result = await _todoService.CreteTodoAsync(todo);
                var responce = AutoMapperUtility<Todo, CreateTodoResponce>.Map(result);

                _logger.LogInformation("Запрос CreateTodoAsync обработан");

                return Ok(responce);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Обновление задачи
        /// </summary>
        /// <param name="request">Запрос обновления задачи</param>
        /// <returns>Обновлённая задача</returns>
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UpdateTodoResponce>> UpdateTodoAsync([FromBody] UpdateTodoRequest request)
        {
            try
            {
                _logger.LogInformation("Запрос UpdateTodoAsync получен");

                var todo = AutoMapperUtility<UpdateTodoRequest, Todo>.Map(request);
                var result = await _todoService.UpdateTodoAsync(todo);
                var responce = AutoMapperUtility<Todo, UpdateTodoResponce>.Map(result);

                _logger.LogInformation("Запрос UpdateTodoAsync обработан");

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
        public async Task<ActionResult> DeleteTodoAsync(int groupId)
        {
            try
            {
                _logger.LogInformation("Запрос DeleteTodoAsync получен");

                await _todoService.DeleteTodoAsync(groupId);

                _logger.LogInformation("Запрос DeleteTodoAsync обработан");

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
