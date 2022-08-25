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
        /// <param name="id">Идентификатор аккаунта</param>
        /// <returns>Аккаунт</returns>
        public Task<Account> GetAccountAsync(int id);

        /// <summary>
        /// Получение аккаунтов друзей
        /// </summary>
        /// <param name="id">Идентификатор аккаунта</param>
        /// <returns>Коллекция аккаунтов друзей</returns>
        public Task<IEnumerable<Account>> GetAccountsByFriendsAsync(int id);

        /// <summary>
        /// Получение аккаунтов группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns>Коллекция аккаунтов группы</returns>
        public Task<IEnumerable<Account>> GetAccountsByGroupAsync(int id);

        /// <summary>
        /// Изменение аватара аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="avatar">Аватар</param>
        public Task UpdateAvatarAsync(int accountId, string avatar);
    }
}