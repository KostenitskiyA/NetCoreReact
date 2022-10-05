using NetCore.Server.Models;

namespace NetCore.Server.Interfaces
{
    /// <summary>
    /// Провайдер аккаунта
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Получение аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns>Аккаунт</returns>
        public Task<Account> GetAccountAsync(int accountId);

        /// <summary>
        /// Получение аккаунтов друзей
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns>Коллекция аккаунтов друзей</returns>
        public Task<IEnumerable<Account>> GetFriendsByAccountAsync(int accountId);

        /// <summary>
        /// Получение аккаунтов группы
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns>Коллекция аккаунтов группы</returns>
        public Task<IEnumerable<Account>> GetAccountsByGroupAsync(int groupId);

        /// <summary>
        /// Поиск аккаунтов по имени
        /// </summary>
        /// <param name="searchName">Имя пользователя</param>
        /// <returns>Коллекция найденных аккаунтов</returns>
        public Task<IEnumerable<Account>> SearchAccountsByNameAsync(string searchName);

        /// <summary>
        /// Поиск аккаунтов группы по имени
        /// </summary>
        /// <param name="groupId">Код группы</param>
        /// <param name="searchName">Имя пользователя</param>
        /// <returns>Коллекция найденных аккаунтов</returns>
        public Task<IEnumerable<Account>> SearchAccountsByNameAsync(string groupId, string searchName);

        /// <summary>
        /// Изменение аватара аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="avatar">Аватар</param>
        public Task UpdateAvatarAsync(int accountId, string avatar);
    }
}