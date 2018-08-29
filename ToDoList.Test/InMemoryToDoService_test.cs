using System;
using System.Collections.Generic;
using ToDoList.CRUD;
using Xunit;

namespace ToDoList.Test
{
    public class InMemoryToDoService_test
    {
        private InMemoryToDoService _service = new InMemoryToDoService();

        [Fact]
        public void Test()
        {
            var sut = new InMemoryToDoService();
            Assert.NotNull(sut);
        }

        //[Fact]
        //public void TestModule()
        //{
        //    var sut = new ToDoModule(_service);
        //    Assert.NotNull(sut);
        //}

        [Fact]
        public void TestModuleAll()
        {
            //var service = new InMemoryToDoService();
            Assert.Empty(_service.All());
        }

        [Theory]
        [InlineData("Testtitel", "Testbeskrivelse")]
        [InlineData("", "Beskrivelse")]
        public void TestModuleAdd(string Title, string Description)
        {
            _service.Add(Title, Description, DateTime.Now);

            Assert.Single(_service.All());
        }

        //Kan dette testes på en bedre måde?
        [Theory]
        [InlineData("Testtitel", "Testbeskrivelse")]
        [InlineData("", "Beskrivelse")]
        [InlineData("Titel", "")]
        [InlineData("", "")]
        public void TestModuleAddProp(string Title, string Description)
        {
            //Action
            ToDoItem todo = _service.Add(Title, Description, DateTime.Now);
            
            //Assert
            Assert.Equal(Title, todo.Title);
            Assert.Equal(Description, todo.Description);
        }

        [Fact]
        public void TestModuleDelete()
        {
            ToDoItem todo = _service.Add("Titel", "Beskrivelse", DateTime.Now);
            Guid ID = todo.ID;
            
            _service.Delete(ID);
            Assert.Empty(_service.All());
        }


        [Theory]
        [InlineData("Testtitel", "", null, false)]
        [InlineData("", "Opdateret beskrivelse", null, true)]
        public void TestModuleUpdate(string Title, string Description, DateTime? Deadline, bool Completed)
        {
            ToDoItem todo = _service.Add("", "", DateTime.Now);
            ToDoItem updToDo = new ToDoItem();

            //Kan updToDo initialiseres på en pænere måde med korrekt titel, beskrivelse, deadline og completed?
            updToDo.Title = Title;
            updToDo.Description = Description;
            updToDo.Deadline = Deadline;
            updToDo.Completed = Completed;

            _service.Update(todo.ID, updToDo);

            Assert.Equal(todo.Title, Title);
            Assert.Equal(todo.Description, Description);
            Assert.Equal(todo.Deadline, Deadline);
            Assert.Equal(todo.Completed, Completed);
        }

        [Fact]
        public void TestDeafultCompleted()
        {
            ToDoItem todo = _service.Add("Testtitel", "Testbeskrivelse", DateTime.Now);

            Assert.False(todo.Completed);
        }

        [Fact]
        public void TestModuleComplete()
        {
            ToDoItem todo = _service.Add("Testtitel", "Testbeskrivelse", DateTime.Now);
            Guid ID = todo.ID;

            _service.Complete(ID);
            Assert.True(todo.Completed);
        }
    }
}