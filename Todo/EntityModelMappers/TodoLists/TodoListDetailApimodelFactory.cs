using System.Collections.Generic;
using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListDetailApimodelFactory
    {
        public static ICollection<TodoItemSummaryApiModel> Create(TodoList todoList)
        {
            return todoList.Items.Select(item => new TodoItemSummaryApiModel(item.TodoItemId, item.Title, new UserSummaryViewmodel(item.ResponsibleParty.UserName, item.ResponsibleParty.Email), item.Importance, item.Rank)).ToList();
        }
    }
}