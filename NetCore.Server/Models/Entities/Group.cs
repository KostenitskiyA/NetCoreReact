namespace NetCore.Server.Models
{
    /// <summary>
    /// Рабочая группа
    /// </summary>
    public class Group
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
        /// Аккаунты группы
        /// </summary>
        public IEnumerable<Account> Accounts { get; set; }

        /// <summary>
        /// Составная таблица Группы-Аккаунты
        /// </summary>
        public IEnumerable<GroupAccount> GroupsAccounts { get; set; }

        /// <summary>
        /// Задачи группы
        /// </summary>
        public IEnumerable<Todo> Todos { get; set; }        
    }
}
