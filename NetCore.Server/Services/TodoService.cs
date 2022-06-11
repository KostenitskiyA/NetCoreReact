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

        public async Task<Todo> GetTodoAsync(int id)
        {
            try
            {
                var foundTodo = await _context.Todos.SingleOrDefaultAsync(t => t.Id == id);

                if (foundTodo == null)
                    throw new Exception("Задача не найдена");

                return foundTodo;
            }
            catch (Exception ex)
            {
                throw;
            }   
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            try
            {
                var foundTodos = await _context.Todos.ToListAsync();

                if (foundTodos == null)
                    throw new Exception("Задачи не найдены");

                return foundTodos;
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

        public async Task<Todo> EditTodoAsync(Todo todo)
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

        public async Task DeleteTodoAsync(int id)
        {
            try
            {
                var foundTodo = await _context.Todos.SingleOrDefaultAsync(t => t.Id == id);

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

        public async Task<IEnumerable<TodoStatus>> GetStatuses()
        {
            try
            {
                var foundTodoStatuses = await _context.TodoStatuses.ToListAsync();

                if (foundTodoStatuses == null)
                    throw new Exception("Статусы не найдены");

                return foundTodoStatuses;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
