using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Логин должен быть заполнен")]
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Пароль должен быть заполнен")]
        public string Password { get; set; } = string.Empty;
    }
}
