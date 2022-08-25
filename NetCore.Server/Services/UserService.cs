using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Services
{
    public class UserService : IUserService
    {
        private ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Account> SignInAsync(User user)
        {
            try
            {
                var createdAccount = await _context.Accounts
                    .AddAsync(user.Account);

                var createdUser = await _context.Users
                    .AddAsync(user);

                await _context.SaveChangesAsync();

                var created = await _context.Users
                    .Include(u => u.Account)
                    .SingleOrDefaultAsync(u => u.Id == createdUser.Entity.Id);

                if (createdUser == null)
                    throw new Exception("Не удалось создать пользователя");

                return created.Account;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Account> LogInAsync(User user)
        {
            try
            {
                var foundUser = await _context.Users
                    .Include(u => u.Account)
                    .SingleOrDefaultAsync(u => u.Login == user.Login
                                            && u.Password == user.Password);

                if (foundUser == null)
                    throw new Exception("Пользователь не найден");

                return foundUser.Account;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
