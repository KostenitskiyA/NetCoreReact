namespace NetCore.Server.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор аккаунта
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Аккаунт пользователя
        /// </summary>
        public Account? Account { get; set; }
    }
}
