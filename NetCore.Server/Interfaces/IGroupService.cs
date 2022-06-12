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
        /// <param name="id">Идентификатор группы</param>
        /// <returns>Группа</returns>
        public Task<Group> GetGroup(int id);

        /// <summary>
        /// Получение групп аккаунта
        /// </summary>
        /// <param name="id">Идентификатор аккаунта</param>
        /// <returns>Коллекция групп</returns>
        public Task<IEnumerable<Group>> GetGroupsByAccount(int id);

        /// <summary>
        /// Создание группы
        /// </summary>
        /// <param name="group">Создаваемая группа</param>
        /// <returns>Созданная группа</returns>
        public Task<Group> CreateGroup(Group group);

        /// <summary>
        /// Обновление группы
        /// </summary>
        /// <param name="group">Обновляемая группа</param>
        /// <returns>Обновлённая группа</returns>
        public Task<Group> UpdateGroup(Group group);

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="id">Идентификатор удаляемой группы</param>
        public Task DeleteGroup(int id);
    }
}
