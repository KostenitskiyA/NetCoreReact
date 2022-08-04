namespace NetCore.Server.Models.Responces
{
    /// <summary>
    /// Ответ получения аккаунта
    /// </summary>
    public class GetAccountResponce
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
    }
}
