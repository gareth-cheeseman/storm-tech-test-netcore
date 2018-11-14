using Microsoft.AspNetCore.Identity;
using Shouldly;
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
            resultFields.UserName.ShouldBe(user.UserName);
        }

        [Fact]
        public void EqualEmail()
        {
            resultFields.Email.ShouldBe(user.Email);
        }

    }
}