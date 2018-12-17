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
        public static TodoListDetailApimodel Create(TodoList todoList)
        {
            var todos = todoList.Items.Select(TodoItemSummaryModelFactory.Create).ToList();

            return new TodoListDetailApimodel(todoList.TodoListId, todoList.Title, todos);
        }
    }
}