using System.Linq;
using Microsoft.AspNetCore.Identity;
using Shouldly;
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
        private readonly TodoItemSummaryModel resultFields;

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

            resultFields = TodoItemSummaryModelFactory.Create(srcTodoItem);
        }

        [Fact]
        public void EqualTodoItemId()
        {
            resultFields.TodoItemId.ShouldBe(srcTodoItem.TodoListId);
        }

        [Fact]
        public void EqualTitle()
        {
            resultFields.Title.ShouldBe(srcTodoItem.Title);
        }

        [Fact]
        public void EqualImportance()
        {
            resultFields.Importance.ShouldBe(srcTodoItem.Importance);
        }

        [Fact]
        public void EqualIsDone()
        {
            resultFields.IsDone.ShouldBe(srcTodoItem.IsDone);
        }

        [Fact]
        public void EqualResponsibleParty()
        {
            var srcResponsibleParty = UserSummaryViewmodelFactory.Create(srcTodoItem.ResponsibleParty);
            resultFields.ResponsibleParty.UserName.ShouldBe(srcResponsibleParty.UserName);
            resultFields.ResponsibleParty.Email.ShouldBe(srcResponsibleParty.Email);
        }
    }
}