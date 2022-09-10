using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Services
{
    public class AccountService : IAccountService
    {
        private ApplicationContext _context;

        public AccountService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountAsync(int id)
        {
            try
            {
                var foundAccount = await _context.Accounts
                    .SingleOrDefaultAsync(u => u.Id == id);

                if (foundAccount == null)
                    throw new Exception("Аккаунт не найден");

                return foundAccount;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /*public async Task<IEnumerable<Account>> GetAccountsByFriendsAsync(int id)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .Include(g => g.Accounts)
                    .SingleOrDefaultAsync(g => g.Id == id);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                if (foundGroup.Accounts == null)
                    throw new Exception("Аккаунты не найдены");

                return foundGroup.Accounts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }*/

        public async Task<IEnumerable<Account>> GetAccountsByGroupAsync(int id)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .Include(g => g.Accounts)
                    .SingleOrDefaultAsync(g => g.Id == id);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                if (foundGroup.Accounts == null)
                    throw new Exception("Аккаунты не найдены");

                return foundGroup.Accounts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Account>> SearchAccountsByNameAsync(string name)
        {
            try
            {
                var foundAccounts = _context.Accounts
                    .Where(a => a.Name.Contains(name));

                if (foundAccounts == null)
                    throw new Exception("Аккаунты не найдены");

                return foundAccounts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Account>> SearchAccountsByNameAsync(string group, string name)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .Include(g => g.Accounts)
                    .SingleOrDefaultAsync(g => g.Code == group);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                if (foundGroup.Accounts == null)
                    throw new Exception("Аккаунты не найдены");

                if (!String.IsNullOrEmpty(name))
                    return foundGroup.Accounts
                        .Where(a => a.Name.Contains(name));

                return foundGroup.Accounts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAvatarAsync(int accountId, string avatar)
        {
            try
            {
                var foundAccount = await _context.Accounts
                    .SingleOrDefaultAsync(a => a.Id == accountId);

                if (foundAccount == null)
                    throw new Exception("Аккаунт не найден");

                foundAccount.Avatar = avatar;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
