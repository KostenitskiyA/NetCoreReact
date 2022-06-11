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
        public Task<User> GetAccountAsync(int id);

        /// <summary>
        /// Получение аккаунтов
        /// </summary>
        /// <returns>Коллекция аккаунтов</returns>
        public Task<IEnumerable<User>> GetAccountAsync();
    }
}
