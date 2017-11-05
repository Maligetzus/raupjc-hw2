
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2;

namespace Zad3
{
    [TestClass]
    public class TodoItemTest
    {
        [TestMethod]
        public void EqualsTest()
        {
            TodoItem todoItem1 = new TodoItem("ćao");
            TodoItem todoItem2 = new TodoItem("ćao");

            Assert.IsFalse(todoItem1.Equals(todoItem2));
        }

        [TestMethod]
        public void MarkAsCompletedTest()
        {
            TodoItem todoItem=new TodoItem("ćao");
            Boolean a = todoItem.MarkAsCompleted();

            Assert.IsTrue(todoItem.IsCompleted);
        }
    }
}
