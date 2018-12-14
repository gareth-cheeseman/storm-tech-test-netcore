using System.Collections.Generic;
using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListDetailApimodelFactory
    {
        public static ICollection<TodoItem> Create(TodoList todoList)
        {
            return todoList.Items.ToList();
        }
    }
}