namespace NetCore.Server.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class Todo
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор статуса задачи
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Статус задачи
        /// </summary>
        public TodoStatus? Status { get; set; }
            
        /// <summary>
        /// Идентификатор создателя
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Создатель задачи
        /// </summary>
        public Account? Creator { get; set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        public Group? Group { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime ChangeDate { get; set; }
    }
}
