using Microsoft.AspNetCore.Identity;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public class UserSummaryViewmodelFactory
    {
        public static UserSummaryModel Create(IdentityUser identityUser)
        {
            return new UserSummaryModel(identityUser.UserName, identityUser.Email);
        }
    }
}