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

        /*/// <summary>
        /// Получение аккаунтов друзей
        /// </summary>
        /// <param name="id">Идентификатор аккаунта</param>
        /// <returns>Коллекция аккаунтов друзей</returns>
        public Task<IEnumerable<Account>> GetAccountsByFriendsAsync(int id);*/

        /// <summary>
        /// Получение аккаунтов группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns>Коллекция аккаунтов группы</returns>
        public Task<IEnumerable<Account>> GetAccountsByGroupAsync(int id);

        /// <summary>
        /// Поиск аккаунтов по имени
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <returns>Коллекция найденных аккаунтов</returns>
        public Task<IEnumerable<Account>> SearchAccountsByNameAsync(string name);

        /// <summary>
        /// Поиск аккаунтов группы по имени
        /// </summary>
        /// <param name="group">Код группы</param>
        /// <param name="name">Имя пользователя</param>
        /// <returns>Коллекция найденных аккаунтов</returns>
        public Task<IEnumerable<Account>> SearchAccountsByNameAsync(string group, string name);

        /// <summary>
        /// Изменение аватара аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="avatar">Аватар</param>
        public Task UpdateAvatarAsync(int accountId, string avatar);
    }
}