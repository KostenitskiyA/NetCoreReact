using NetCore.Server.Models;

namespace NetCore.Server.Interfaces
{
    /// <summary>
    /// Провайдер задач
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Получение статусов
        /// </summary>
        /// <returns>Коллекция статусов</returns>
        public Task<IEnumerable<TodoStatus>> GetStatuses();

        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Задача</returns>
        public Task<Todo> GetTodoAsync(int id);

        /// <summary>
        /// Получение задач группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns>Коллекция задач группы</returns>
        public Task<IEnumerable<Todo>> GetTodosByGroupAsync(int id);

        /// <summary>
        /// Получение задач аккаунта
        /// </summary>
        /// <param name="id">Идентификатор аккаунта</param>
        /// <returns>Коллекция задач аккаунта</returns>
        public Task<IEnumerable<Todo>> GetTodosByAccountAsync(int id);

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="todo">Создаваемая задача</param>
        /// <returns>Созданная задача</returns>
        public Task<Todo> CreteTodoAsync(Todo todo);

        /// <summary>
        /// Обновление задачи
        /// </summary>
        /// <param name="todo">Обновляемая задача</param>
        /// <returns>Обновлённая задача</returns>
        public Task<Todo> UpdateTodoAsync(Todo todo);

        /// <summary>
        /// Удаление задача
        /// </summary>
        /// <param name="id">Идентификатор удаляемой задачи</param>
        public Task DeleteTodoAsync(int id);
    }
}
