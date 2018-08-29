using Microsoft.Owin;
using Nancy;
using FluentValidation;
using Nancy.ModelBinding;
using Nancy.Validation;
using System;

namespace ToDoList
{
    public class ToDoModule : NancyModule
    {
        private readonly IToDoService _todoService;

        public ToDoModule(IToDoService todoService)
        {
            if (todoService == null)
                throw new ArgumentNullException(nameof(todoService));

            this._todoService = todoService;

            Post["/to-do/"] = AddToDo;

            Get["/to-do-list/"] = AllToDos;

            Delete["/to-do/{ID}/"] = DeleteToDo;

            Post["/to-do/{ID}/"] = UpdateToDo;

            Post["/to-do/complete/{ID}/"] = CompleteToDo;
        }

        public object AddToDo(dynamic parameters)
        {
            var todoInfo = this.Bind<ToDoItem>("ID", "Completed");
            var validationResult = this.Validate(todoInfo);

            if (!validationResult.IsValid)
            {
                return Negotiate.WithModel(validationResult).WithStatusCode(HttpStatusCode.BadRequest);
            }

            try
            {
                _todoService.Add(todoInfo.Title, todoInfo.Description, todoInfo.Deadline);
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }

            return HttpStatusCode.OK;
         }

        public object DeleteToDo(dynamic parameters)
        {
            try
            {
                _todoService.Delete(parameters.ID);
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
            return HttpStatusCode.OK;
        }

        public object AllToDos(dynamic parameters)
        {
            try
            {
                _todoService.All();
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }

            return HttpStatusCode.OK;
        }

        public object UpdateToDo(dynamic parameters)
        {
            var todoUpdate = this.Bind<ToDoItem>();
            var validationResult = this.Validate(todoUpdate);

            if (!validationResult.IsValid)
            {
                return Negotiate.WithModel(validationResult).WithStatusCode(HttpStatusCode.BadRequest);
            }

            try
            {
                _todoService.Update(parameters.ID, todoUpdate);
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
            return HttpStatusCode.OK;
        }

        public object CompleteToDo(dynamic parameters)
        {
            try
            {
                _todoService.Complete(parameters.ID);
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
            return HttpStatusCode.OK;
        }
    }
}
