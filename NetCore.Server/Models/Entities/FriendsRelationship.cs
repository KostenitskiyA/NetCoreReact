namespace NetCore.Server.Models.Entities
{
    /// <summary>
    /// Дружеские отношения
    /// </summary>
    public class FriendsRelationship
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор аккаунта
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Аккаунт
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Идентификатор аккаунта друга
        /// </summary>
        public int FriendId { get; set; }
    }
}
