using NetCore.Server.Models;

namespace NetCore.Server.Interfaces
{
    /// <summary>
    /// Провайдер задач
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Задача</returns>
        public Task<Todo> GetTodoAsync(int id);

        /// <summary>
        /// Получение задач
        /// </summary>
        /// <returns>Коллекция задач</returns>
        public Task<IEnumerable<Todo>> GetTodosAsync();

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="todo">Создаваемая задача</param>
        /// <returns>Созданная задача</returns>
        public Task<Todo> CreteTodoAsync(Todo todo);

        /// <summary>
        /// Изменение задача
        /// </summary>
        /// <param name="todo">Изменяемая задача</param>
        /// <returns>Изменённая задача</returns>
        public Task<Todo> EditTodoAsync(Todo todo);

        /// <summary>
        /// Удаление задача
        /// </summary>
        /// <param name="id">Идентификатор удаляемой задачи</param>
        public Task DeleteTodoAsync(int id);

        /// <summary>
        /// Получение статусов
        /// </summary>
        /// <returns>Коллекция статусов</returns>
        public Task<IEnumerable<TodoStatus>> GetStatuses();
    }
}
