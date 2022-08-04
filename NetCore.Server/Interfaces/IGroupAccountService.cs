using NetCore.Server.Models;

namespace NetCore.Server.Interfaces
{
    /// <summary>
    /// Провайдер групп-аккаунт
    /// </summary>
    public interface IGroupAccountService
    {
        /// <summary>
        /// Создание группа-аккаунт
        /// </summary>
        /// <param name="group">Создаваемая группа-аккаунт</param>
        /// <returns>Созданная группа-аккаунт</returns>
        public Task<GroupAccount> CreateGroupAccountAsync(GroupAccount groupAccount);

        /// <summary>
        /// Удаление группа-аккаунт
        /// </summary>
        /// <param name="id">Идентификатор удаляемой группа-аккаунт</param>
        public Task DeleteGroupAccountAsync(int groupId, int accountId);

        /// <summary>
        /// Удаление всех записей группа-аккаунт группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        public Task DeleteAllGroupAccountByGroupAsync(int groupId);
    }
}
