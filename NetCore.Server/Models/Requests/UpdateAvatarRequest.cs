namespace NetCore.Server.Models.Requests
{
    /// <summary>
    /// Запрос изменения аватара
    /// </summary>
    public class UpdateAvatarRequest
    {
        /// <summary>
        /// Идентификатор аккаунта
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Аватар
        /// </summary>
        public string Avatar { get; set; } = string.Empty;
    }
}
