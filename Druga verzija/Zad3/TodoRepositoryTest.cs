using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zad3
{
    [TestClass]
    public class TodoRepositoryTest
    {
        [TestMethod]
        public void AddTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem = todoRepository.Add(new TodoItem("ćao"));
            Assert.IsTrue(todoItem.Equals(todoRepository.Get(todoItem.Id)));
        }

        [TestMethod]
        public void GetTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem=new TodoItem("hoj");
            todoRepository.Add(todoItem);
            Assert.IsTrue(todoItem.Equals(todoRepository.Get(todoItem.Id)));
        }

        [TestMethod]
        public void RemoveTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            Console.WriteLine("broj" + todoRepository.GetAll().Count());
            TodoItem todoItem = new TodoItem("hoj");
            todoRepository.Add(todoItem);
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));
            int count = todoRepository.GetAll().Count();
            todoRepository.Remove(todoItem.Id);
            Assert.IsTrue(count-1==todoRepository.GetAll().Count());
        }

        [TestMethod]
        public void GetAllTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem = new TodoItem("hoj");
            todoRepository.Add(todoItem);
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));
            todoRepository.Add(new TodoItem("haj"));
            todoItem.MarkAsCompleted();
            Assert.IsTrue(todoRepository.GetAll().Count==4);
        }

        [TestMethod]
        public void GetActiveTest()
        {
            TodoRepository todoRepository=new TodoRepository();
            TodoItem todoItem = new TodoItem("hoj");
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));
            todoItem.MarkAsCompleted();
            Assert.IsTrue(todoRepository.GetActive().Count==2);
        }

        [TestMethod]
        public void GetFilteredTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem = new TodoItem("hoj");
            todoRepository.Add(todoItem);
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));
            todoRepository.MarkAsCompleted(todoItem.Id);
            Assert.IsTrue(todoRepository.GetFiltered(p=>p.IsCompleted).Count == 1);
        }

        [TestMethod]
        public void GetCompletedTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem = new TodoItem("hoj");
            todoRepository.Add(todoItem);
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));
            todoRepository.MarkAsCompleted(todoItem.Id);
            Console.WriteLine(todoRepository.GetCompleted().Count);
            Assert.IsTrue(todoRepository.GetCompleted().Count == 1);
        }
    }
}