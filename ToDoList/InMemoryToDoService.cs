using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList
{ 
    public class InMemoryToDoService : IToDoService
    {
        private List<ToDoItem> _list = new List<ToDoItem>();

        public ToDoItem Add(string title, string description, DateTime? deadline)
        {
            ToDoItem todo = new ToDoItem();

            todo.ID = Guid.NewGuid();
            todo.Title = title;
            todo.Description = description;
            todo.Deadline = deadline;

            _list.Add(todo);
            return todo;
        }

        public void Delete(Guid ID)
        {
            ToDoItem todo = _list.FirstOrDefault(x => x.ID == ID);
            if (todo == null)
                throw new Exception("Unable to find todo item with ID " + ID.ToString("D)"));

            _list.Remove(todo);
        }

        public List<ToDoItem> All()
        {
            return _list;
        }

        public void Update(Guid ID, ToDoItem todoUpdate)
        {
            ToDoItem todo = _list.FirstOrDefault(x => x.ID == ID);
            if (todo == null)
                throw new Exception("Unable to find todo item with ID " + ID.ToString("D)"));

            todo.Title = todoUpdate.Title;
            todo.Description = todoUpdate.Description;
            todo.Deadline = todoUpdate.Deadline;
            if (!todo.Completed.Equals(todoUpdate.Completed))
            {
                todo.Completed = todoUpdate.Completed;
            }
        }

        public void Complete(Guid ID)
        {
            ToDoItem todo = _list.Find(x => x.ID == ID);

            todo.Completed = true;
        }
    }
}