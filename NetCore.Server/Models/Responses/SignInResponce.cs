namespace NetCore.Server.Models.Responces
{
    /// <summary>
    /// Ответ регистрации пользователя
    /// </summary>
    public class SignInResponce
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
