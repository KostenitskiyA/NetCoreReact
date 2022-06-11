namespace NetCore.Server.Models.Responces
{
    /// <summary>
    /// Ответ создания рабочей группы
    /// </summary>
    public class CreateGroupResponce
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Владелец группы
        /// </summary>
        public Account Owner { get; set; }
    }
}
