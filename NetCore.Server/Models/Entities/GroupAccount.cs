namespace NetCore.Server.Models
{
    /// <summary>
    /// Группа-Аккаунт
    /// </summary>
    public class GroupAccount
    {
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Идентификатор аккаунта
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Аккаунт
        /// </summary>
        public Account Account { get; set; }
    }
}
