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

        public async Task<Group> GetGroup(int id)
        {
            try 
            {
                var foundGroup = await _context.Groups.SingleOrDefaultAsync(g => g.Id == id);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                return foundGroup;
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        // TODO: Доработать под many-to-many
        public async Task<IEnumerable<Group>> GetGroups(int id)
        {
            try
            {
                var foundGroups = await _context.Groups.Include(g => g.Users)
                    .Where(g => g.Users.)
                    .ToListAsync();

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                return foundGroup;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Group> CreateGroup(Group group)
        {
            try
            {
                var createdGroup = await _context.Groups.AddAsync(group);

                if (createdGroup == null)
                    throw new Exception("Группа не создана");

                await _context.SaveChangesAsync();

                return createdGroup.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }        

        public async Task<Group> EditGroup(Group group)
        {
            try
            {
                var foundGroup = await _context.Groups.SingleOrDefaultAsync(g => g.Id == group.Id);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                var editedTodo = _context.Groups.Update(foundGroup);

                if (editedTodo == null)
                    throw new Exception("Группа не изменена");

                await _context.SaveChangesAsync();

                return editedTodo.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteGroup(int id)
        {
            try
            {
                var foundGroup = await _context.Groups.SingleOrDefaultAsync(g => g.Id == id);
                
                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                _context.Groups.Remove(foundGroup);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
