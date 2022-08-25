namespace NetCore.Server.Models.Entities
{
    /// <summary>
    /// Аккаунт-Аккаунт
    /// </summary>
    public class AccountAccount
    {
        /// <summary>
        /// Идентификатор аккаунта
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Аккаунт
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Идентификатор друга
        /// </summary>
        public int FriendId { get; set; }

        /// <summary>
        /// Друг
        /// </summary>
        public Account Friend { get; set; }
    }
}
