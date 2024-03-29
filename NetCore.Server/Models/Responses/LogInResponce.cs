﻿namespace NetCore.Server.Models.Responces
{
    /// <summary>
    /// Ответ входа пользователя
    /// </summary>
    public class LogInResponce
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Аватар
        /// </summary>
        public string Avatar { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
