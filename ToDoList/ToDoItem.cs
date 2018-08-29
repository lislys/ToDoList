using FluentValidation;
using System;

namespace ToDoList
{
    public class ToDoItem
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        //Default value af bool er false.
        public bool Completed { get; set; }
    }

    public class AddToDoValidator : AbstractValidator<ToDoItem>
    {
        public AddToDoValidator()
        {
            RuleFor(request => request.Title).NotEmpty().WithMessage("You must specify a title.");
            RuleFor(request => request.Title).Length(1, 100).WithMessage("The maximum title length is 100 characters.");
            RuleFor(request => request.Deadline).GreaterThan(DateTime.Now.Date).WithMessage("Choose a date after today.");
        }
    }
}