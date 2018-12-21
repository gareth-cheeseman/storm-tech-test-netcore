using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListDetailApimodelFactory
    {
        public static TodoListDetailApimodel Create(TodoList todoList)
        {
            var items = todoList.Items.OrderBy(item => item.Importance);
            var apiModelItems = items.Select(TodoItemSummaryModelFactory.Create).ToList();

            return new TodoListDetailApimodel(todoList.TodoListId, todoList.Title, apiModelItems);
        }
    }
}