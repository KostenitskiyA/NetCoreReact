using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Services
{
    public class GroupAccountService : IGroupAccountService
    {
        private ApplicationContext _context;

        public GroupAccountService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<GroupAccount> CreateGroupAccountAsync(GroupAccount groupAccount)
        {
            try
            {
                var createdGroupAccount = await _context.GroupsAccounts
                    .AddAsync(groupAccount);

                if (createdGroupAccount.Entity == null)
                    throw new Exception("Группа-аккаунт не создана");

                await _context.SaveChangesAsync();

                return createdGroupAccount.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }      

        public async Task DeleteGroupAccountAsync(int groupId, int accountId)
        {
            try
            {
                var foundGroupAccount = await _context.GroupsAccounts
                    .SingleOrDefaultAsync(g => g.GroupId == groupId 
                                            && g.AccountId == accountId);

                if (foundGroupAccount == null)
                    throw new Exception("Группа-аккаунт не найдена");

                _context.GroupsAccounts
                    .Remove(foundGroupAccount);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAllGroupAccountByGroupAsync(int groupId)
        {
            try
            {
                var foundGroupAccount = await _context.GroupsAccounts
                    .Where(g => g.GroupId == groupId)
                    .ToListAsync();

                if (foundGroupAccount == null)
                    throw new Exception("Группа-аккаунт не найдены");

                _context.GroupsAccounts
                    .RemoveRange(foundGroupAccount);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
