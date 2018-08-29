using System;
using Microsoft.Owin;
using System.Collections.Generic;

namespace ToDoList
{
    public interface IToDoService
    {
        //Returner ToDoItem??
        ToDoItem Add(string title, string description, DateTime? deadline);

        void Delete(Guid ID);

        List<ToDoItem> All();

        void Update(Guid ID, ToDoItem todoUpdate);

        void Complete(Guid ID);
    }
}
