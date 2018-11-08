using Microsoft.AspNetCore.Identity;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Xunit;

namespace Todo.Tests.FieldFactoryTests
{
    public class WhenUserIsConvertedToUserSummaryView
    {
        private readonly IdentityUser user;
        private readonly UserSummaryViewmodel resultFields;

        public WhenUserIsConvertedToUserSummaryView()
        {
           user = new IdentityUser("alice@example.com");
            user.Email = "alice@example.com1";
    

            resultFields = UserSummaryViewmodelFactory.Create(user);
        }

        [Fact]
        public void EqualUsername()
        {
            Assert.Equal(user.UserName, resultFields.UserName);
        }

        [Fact]
        public void EqualEmail()
        {
            Assert.Equal(user.Email, resultFields.Email);
        }

    }
}