using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public static class TodoItemSummaryModelFactory
    {
        public static TodoItemSummaryModel Create(TodoItem ti)
        {
            return new TodoItemSummaryModel(ti.TodoItemId, ti.Title, ti.IsDone, UserSummaryViewmodelFactory.Create(ti.ResponsibleParty), ti.Importance, ti.Rank);
        }
    }
}