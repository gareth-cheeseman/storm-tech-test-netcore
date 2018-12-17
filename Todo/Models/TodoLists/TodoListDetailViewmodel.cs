using System.Collections.Generic;
using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListDetailViewmodel
    {
        public int TodoListId { get; }
        public string Title { get; }
        public ICollection<TodoItemSummaryModel> Items { get; }
        public bool HideDone { get; set; }
        public bool OrderByRank { get; set; }

        public TodoListDetailViewmodel(int todoListId, string title, ICollection<TodoItemSummaryModel> items, bool hideDone, bool orderByRank)
        {
            Items = items;
            TodoListId = todoListId;
            Title = title;
            HideDone = hideDone;
            OrderByRank = orderByRank;
        }
    }
}