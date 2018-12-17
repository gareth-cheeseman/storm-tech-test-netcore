namespace Todo.Models.TodoItems
{
    public class UserSummaryModel
    {
        public string UserName { get; }
        public string Email { get; }

        public UserSummaryModel(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}