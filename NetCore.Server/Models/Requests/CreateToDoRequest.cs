namespace NetCore.Server.Models.Requests
{
    /// <summary>
    /// Запрос создания задачи
    /// </summary>
    public class CreateTodoRequest
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Идентификатор создателя
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public int GroupId { get; set; }
    }
}
