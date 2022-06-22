namespace NetCore.Server.Models.Responces
{
    /// <summary>
    /// Ответ на запрос Создания задачи
    /// </summary>
    public class UpdateTodoResponce
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; } = String.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = String.Empty;

        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Идентификатор создателя задачи
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Идентификатор исполнителя задачи
        /// </summary>
        public int ExecutorId { get; set; }
    }
}
