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
    public class WhenTodoItemIsConvertedToEditFields
    {
        private readonly TodoItem srcTodoItem;
        private readonly TodoItemEditFields resultFields;

        public WhenTodoItemIsConvertedToEditFields()
        {
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                    .WithItem("bread", Importance.High)
                    .Build();

            srcTodoItem = todoList.Items.First();

            resultFields = TodoItemEditFieldsFactory.Create(srcTodoItem);
        }

        [Fact]
        public void EqualTodoListId()
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
    }
}