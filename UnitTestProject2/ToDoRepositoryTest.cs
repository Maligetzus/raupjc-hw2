
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2;

namespace Zad3
{
    [TestClass]
    public class TodoRepostioryTest
    {
        [TestMethod]
        public void AddGetAllTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));
            
            Assert.IsTrue(todoRepository.GetAll().Count() == 2);
        }

        [TestMethod]
        public void GetTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem=new TodoItem("hoj");
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));

            Assert.IsTrue(Equals(todoRepository.Get(todoItem.Id), todoItem));
        }

        [TestMethod]
        public void RemoveTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem = new TodoItem("hoj");
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));
            int a = todoRepository.GetAll().Count();
            todoRepository.Remove(todoItem.Id);

            Assert.IsTrue(a-1==todoRepository.GetAll().Count());
        }

        [TestMethod]
        public void GetActiveGetFilteredGetCompletedTest()
        {
            TodoRepository todoRepository = new TodoRepository();
            TodoItem todoItem = new TodoItem("hoj");
            todoRepository.Add(new TodoItem("ćao"));
            todoRepository.Add(new TodoItem("hej"));
            todoRepository.GetCompleted();
            todoRepository.Add(todoItem);

            Assert.IsTrue(todoRepository.GetCompleted().Count()==todoRepository.GetFiltered(p => p.IsCompleted).Count() && todoRepository.GetFiltered(p => p.IsCompleted).Count() == (todoRepository.GetActive().Count()-1));
        }
    }
}
