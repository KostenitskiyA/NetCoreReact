namespace NetCore.Server.Models.Requests
{
    /// <summary>
    /// Запрос обновления группы
    /// </summary>
    public class UpdateGroupRequest
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
