using System.Collections.Generic;
using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListDetailApimodel
    {
        public int TodoListId { get; }
        public string Title { get; }
        public ICollection<TodoItemSummaryModel> Items { get; }

        public TodoListDetailApimodel(int todoListId, string title, ICollection<TodoItemSummaryModel> items)
        {
            Items = items;
            TodoListId = todoListId;
            Title = title;
        }
    }
}