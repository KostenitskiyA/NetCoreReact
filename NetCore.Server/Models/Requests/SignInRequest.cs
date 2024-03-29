﻿namespace NetCore.Server.Models.Requests
{
    /// <summary>
    /// Запрос регистрации пользователя
    /// </summary>
    public class SignInRequest
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
