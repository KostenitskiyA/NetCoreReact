namespace NetCore.Server.Models.Requests
{
    /// <summary>
    /// Запрос входа пользователя
    /// </summary>
    public class LogInRequest
    {
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
