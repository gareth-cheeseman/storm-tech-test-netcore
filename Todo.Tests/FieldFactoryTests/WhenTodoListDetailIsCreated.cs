using System.Linq;
using Microsoft.AspNetCore.Identity;
using Shouldly;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.TodoItems;
using Todo.Models.TodoLists;
using Todo.Tests.TodoListUtilities;
using Xunit;

namespace Todo.Tests.FieldFactoryTests
{
    public class WhenTodoListDetailIsCreated
    {
        private readonly TodoList srcTodoList;
        private readonly TodoListDetailViewmodel resultFields;

        public WhenTodoListDetailIsCreated()
        {
            srcTodoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                    .WithItem("bread", Importance.High)
                    .WithItem("milk", Importance.High)
                    .WithItem("cheese", Importance.Medium)
                    .WithItem("lettuce", Importance.Low)
                    .WithItem("tomato", Importance.Medium)
                    .Build();

            resultFields = TodoListDetailViewmodelFactory.Create(srcTodoList, false);
        }

        [Fact]
        public void EqualTodoListId()
        {
            resultFields.TodoListId.ShouldBe(srcTodoList.TodoListId);
        }

        [Fact]
        public void EqualTitle()
        {
            resultFields.Title.ShouldBe(srcTodoList.Title);
        }

        [Fact]
        public void EqualItemsCount()
        {
            resultFields.Items.Count.ShouldBe(srcTodoList.Items.Count);
        }

        [Fact]
        public void ItemsOrderedByImportance()
        {
            resultFields.Items.Select(item => item.Title).ShouldBe(srcTodoList.Items.OrderBy(item => item.Importance).Select(item => item.Title));
        }

    }
}