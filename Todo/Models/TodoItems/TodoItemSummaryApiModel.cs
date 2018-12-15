using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemSummaryApiModel
    {
        public int TodoItemId { get; }
        public string Title { get; }
        public UserSummaryViewmodel ResponsibleParty { get; }
        public Importance Importance { get; }
        public int Rank { get; }

        public TodoItemSummaryApiModel(int todoItemId, string title, UserSummaryViewmodel responsibleParty, Importance importance, int rank)
        {
            TodoItemId = todoItemId;
            Title = title;
            ResponsibleParty = responsibleParty;
            Importance = importance;
            Rank = rank;
        }
    }
}