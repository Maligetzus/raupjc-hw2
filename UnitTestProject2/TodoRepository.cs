using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will
            // return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(p => p.Id.Equals(todoId));
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem)) return null;
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
        }

        public bool Remove(Guid todoId)
        {
            TodoItem todoItem = _inMemoryTodoDatabase.FirstOrDefault(p => p.Id.Equals(todoId));
            if (todoItem == null) return false;
            else
            {
                _inMemoryTodoDatabase.Remove(todoItem);
                return true;
            }
        }

        public TodoItem Update(TodoItem todoItem)
        {
            Remove(todoItem.Id);
            return Add(todoItem);
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem todoItem = Get(todoId);
            return todoItem.MarkAsCompleted();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(p => p.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(p => !(p.IsCompleted)).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(p => p.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }
}
