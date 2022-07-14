namespace NetCore.Server.Models
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public class TodoStatus
    {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Задачи статуса
        /// </summary>
        public IEnumerable<Todo> Todos { get; set; }
    }
}
