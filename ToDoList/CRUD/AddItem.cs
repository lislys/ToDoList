using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.CRUD
{
    public class AddItem
    {
        private IToDoService _service;

        public AddItem(IToDoService service)
        {
            _service = service;
        }

        public ToDoItem Add(ToDoItem item)
        {
            return _service.Add(item.Title, item.Description, item.Deadline);
        }
    }

}