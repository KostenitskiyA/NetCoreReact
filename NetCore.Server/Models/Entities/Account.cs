namespace NetCore.Server.Models
{
    /// <summary>
    /// Аккаунт
    /// </summary>
    public class Account
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
        /// Пользователь аккаунта
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Группы аккаунты
        /// </summary>
        public IEnumerable<Group>? Groups { get; set; }

        /// <summary>
        /// Составная таблица Группы-Аккаунты
        /// </summary>
        public IEnumerable<GroupAccount>? GroupsAccounts { get; set; }

        /// <summary>
        /// Задачи аккаунта
        /// </summary>
        public IEnumerable<Todo>? Todos { get; set; }
    }
}
