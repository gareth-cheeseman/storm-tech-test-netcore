using System.Collections.Generic;
using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListDetailViewmodelFactory
    {
        public static TodoListDetailViewmodel Create(TodoList todoList, bool hideDone, bool orderByRank)
        {
            var items = hideDone ?
                todoList.Items.Where(ti => !ti.IsDone) :
                todoList.Items;

            items = orderByRank ?
                items.OrderBy(item => item.Rank)
                     .ThenBy(item => item.Importance) :
                items.OrderBy(item => item.Importance);

            var viewModelItems = items.Select(TodoItemSummaryViewmodelFactory.Create).ToList();

            return new TodoListDetailViewmodel(todoList.TodoListId, todoList.Title, viewModelItems, hideDone, orderByRank);
        }
    }
}