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
        /// Идентификатор владелеца группы
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Владелец группы
        /// </summary>
        public Account Owner { get; set; }

        /*/// <summary>
        /// Аккаунты группы
        /// </summary>
        public IEnumerable<Account> Accounts { get; set; }
              
        /// <summary>
        /// Задачи группы
        /// </summary>
        public IEnumerable<Todo> Todos { get; set; }

        /// <summary>
        /// Составная таблица Группы-Аккаунты
        /// </summary>
        public IEnumerable<GroupAccount> GroupAccounts { get; set; }*/
    }
}
