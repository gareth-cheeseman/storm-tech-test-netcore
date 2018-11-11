using System.Linq;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Todo.Tests.TodoListUtilities;
using Xunit;

namespace Todo.Tests.FieldFactoryTests
{
    public class WhenTodoItemIsConvertedToSummaryView
    {
        private readonly TodoItem srcTodoItem;
        private readonly TodoItemSummaryViewmodel resultFields;

        public WhenTodoItemIsConvertedToSummaryView()
        {
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                    .WithItem("bread", Importance.High)
                    .Build()
                ;

            srcTodoItem = todoList.Items.First();

            //change IsDone to true because default is false.
            srcTodoItem.IsDone = true;
            srcTodoItem.ResponsibleParty = todoList.Owner;

            resultFields = TodoItemSummaryViewmodelFactory.Create(srcTodoItem);
        }

        [Fact]
        public void EqualTodoItemId()
        {
            Assert.Equal(srcTodoItem.TodoListId, resultFields.TodoItemId);
        }

        [Fact]
        public void EqualTitle()
        {
            Assert.Equal(srcTodoItem.Title, resultFields.Title);
        }

        [Fact]
        public void EqualImportance()
        {
            Assert.Equal(srcTodoItem.Importance, resultFields.Importance);
        }

        [Fact]
        public void EqualIsDone()
        {
            Assert.Equal(srcTodoItem.IsDone, resultFields.IsDone);
        }

        [Fact]
        public void EqualResponsibleParty()
        {
            Assert.Equal(UserSummaryViewmodelFactory.Create(srcTodoItem.ResponsibleParty).UserName, resultFields.ResponsibleParty.UserName);
            Assert.Equal(UserSummaryViewmodelFactory.Create(srcTodoItem.ResponsibleParty).Email, resultFields.ResponsibleParty.Email);

        }
    }
}