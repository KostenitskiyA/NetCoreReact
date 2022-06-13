namespace NetCore.Server.Models.Requests
{
    /// <summary>
    /// Запрос создания рабочей группы
    /// </summary>
    public class CreateGroupRequest
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор владелеца группы
        /// </summary>
        public int OwnerId { get; set; }
    }
}
