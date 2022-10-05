using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Services
{
    public class GroupService : IGroupService
    {
        private ApplicationContext _context;

        public GroupService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Group> GetGroupAsync(int groupId)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .SingleOrDefaultAsync(g => g.Id == groupId);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                return foundGroup;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Group>> GetGroupsByAccountAsync(int accountId)
        {
            try
            {
                var foundUser = await _context.Accounts
                    .Include(a => a.Groups)
                    .SingleOrDefaultAsync(a => a.Id == accountId);

                if (foundUser == null)
                    throw new Exception("Пользователь не найден");

                if (foundUser.Groups == null)
                    throw new Exception("Группы не найдены");

                return foundUser.Groups;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Group> CreateGroupAsync(Group group)
        {
            try
            {
                var createdGroup = await _context.Groups
                    .AddAsync(group);

                if (createdGroup.Entity == null)
                    throw new Exception("Группа не создана");

                await _context.SaveChangesAsync();

                return createdGroup.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Group> UpdateGroupAsync(Group group)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .SingleOrDefaultAsync(g => g.Id == group.Id);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                var editedTodo = _context.Groups
                    .Update(foundGroup);

                if (editedTodo == null)
                    throw new Exception("Группа не обновлена");

                await _context.SaveChangesAsync();

                return editedTodo.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .SingleOrDefaultAsync(g => g.Id == groupId);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                _context.Groups
                    .Remove(foundGroup);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
