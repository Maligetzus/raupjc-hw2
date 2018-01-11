using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad3
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
            if (_inMemoryTodoDatabase.Contains(todoItem)) throw new DuplicateTodoItemException(todoItem.Id.ToString());
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            TodoItem todoItem = _inMemoryTodoDatabase.FirstOrDefault(p => p.Id.Equals(todoId));
            if (todoItem == null) return false;
            _inMemoryTodoDatabase.Remove(todoItem);
            if (_inMemoryTodoDatabase.Contains(Get(todoId))) return false;
            return true;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            Remove(todoItem.Id);
            return Add(todoItem);
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            return Get(todoId).MarkAsCompleted();
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

        public class DuplicateTodoItemException : Exception
        {
            private string _id;
            public DuplicateTodoItemException(string id)
            {
                _id = id;
                Console.WriteLine("duplicate id: " + id);
            }
        }
    }
}
