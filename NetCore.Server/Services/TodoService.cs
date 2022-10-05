using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;

namespace NetCore.Server.Services
{
    public class TodoService : ITodoService
    {
        private ApplicationContext _context;

        public TodoService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoStatus>> GetStatuses()
        {
            try
            {
                var foundTodoStatuses = await _context.TodoStatuses
                    .ToListAsync();

                if (foundTodoStatuses == null)
                    throw new Exception("Статусы не найдены");

                return foundTodoStatuses;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Todo> GetTodoAsync(int todoId)
        {
            try
            {
                var foundTodo = await _context.Todos
                    .SingleOrDefaultAsync(t => t.Id == todoId);

                if (foundTodo == null)
                    throw new Exception("Задача не найдена");

                return foundTodo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Todo>> GetTodosByGroupAsync(int groupId)
        {
            try
            {
                var foundGroup = await _context.Groups
                    .Include(g => g.Todos)
                    .SingleOrDefaultAsync(g => g.Id == groupId);

                if (foundGroup == null)
                    throw new Exception("Группа не найдена");

                if (foundGroup.Todos == null)
                    throw new Exception("Задачи не найдены");

                return foundGroup.Todos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Todo>> GetTodosByAccountAsync(int accountId)
        {
            try
            {
                var foundAccount = await _context.Accounts
                    .Include(a => a.Todos)
                    .SingleOrDefaultAsync(a => a.Id == accountId);

                if (foundAccount == null)
                    throw new Exception("Аккаунт не найден");

                if (foundAccount.Todos == null)
                    throw new Exception("Задачи не найдены");

                return foundAccount.Todos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Todo> CreteTodoAsync(Todo todo)
        {
            try
            {
                var createdTodo = await _context.Todos.AddAsync(todo);
                await _context.SaveChangesAsync();

                return createdTodo.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Todo> UpdateTodoAsync(Todo todo)
        {
            try
            {
                var editedTodo = _context.Todos.Update(todo);
                await _context.SaveChangesAsync();

                return editedTodo.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteTodoAsync(int todoId)
        {
            try
            {
                var foundTodo = await _context.Todos
                    .SingleOrDefaultAsync(t => t.Id == todoId);

                if (foundTodo == null)
                    throw new Exception("Задача не найдена");

                _context.Todos.Remove(foundTodo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
