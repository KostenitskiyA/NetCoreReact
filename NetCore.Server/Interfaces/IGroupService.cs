using NetCore.Server.Models;

namespace NetCore.Server.Interfaces
{
    /// <summary>
    /// Провайдер групп
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Получение группы
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns>Группа</returns>
        public Task<Group> GetGroupAsync(int groupId);

        /// <summary>
        /// Получение групп аккаунта
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns>Коллекция групп</returns>
        public Task<IEnumerable<Group>> GetGroupsByAccountAsync(int accountId);

        /// <summary>
        /// Создание группы
        /// </summary>
        /// <param name="group">Создаваемая группа</param>
        /// <returns>Созданная группа</returns>
        public Task<Group> CreateGroupAsync(Group group);

        /// <summary>
        /// Обновление группы
        /// </summary>
        /// <param name="group">Обновляемая группа</param>
        /// <returns>Обновлённая группа</returns>
        public Task<Group> UpdateGroupAsync(Group group);

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="groupId">Идентификатор удаляемой группы</param>
        public Task DeleteGroupAsync(int groupId);
    }
}
