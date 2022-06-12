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
        /// Получение аккаунтов группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns>Коллекция аккаунтов группы</returns>
        public Task<IEnumerable<Account>> GetAccountsByGroupAsync(int id);
    }
}
