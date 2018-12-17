using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemSummaryModel
    {
        public int TodoItemId { get; }
        public string Title { get; }
        public UserSummaryModel ResponsibleParty { get; }
        public bool IsDone { get; }
        public Importance Importance { get; }
        public int Rank { get; }

        public TodoItemSummaryModel(int todoItemId, string title, bool isDone, UserSummaryModel responsibleParty, Importance importance, int rank)
        {
            TodoItemId = todoItemId;
            Title = title;
            IsDone = isDone;
            ResponsibleParty = responsibleParty;
            Importance = importance;
            Rank = rank;
        }
    }
}