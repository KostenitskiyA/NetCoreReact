﻿namespace NetCore.Server.Models.Responces
{
    /// <summary>
    /// Ответ обновления группы
    /// </summary>
    public class UpdateGroupResponce
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
        /// Id статуса
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Id создателя задачи
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Id исполнителя задачи
        /// </summary>
        public int ExecutorId { get; set; }
    }
}
