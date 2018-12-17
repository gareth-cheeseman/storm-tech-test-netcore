using Microsoft.AspNetCore.Identity;
using Shouldly;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.TodoLists;
using Todo.Tests.TodoListUtilities;
using Xunit;

namespace Todo.Tests.ApiModelTests
{
    public class WhenTodoListApiModelIsCreated
    {
        private readonly TodoList srcTodoList;
        private readonly TodoListDetailApimodel result;

        public WhenTodoListApiModelIsCreated()
        {
            srcTodoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .WithItem("milk", Importance.High)
                .WithItem("cheese", Importance.Medium)
                .WithItem("lettuce", Importance.Low)
                .WithItem("tomato", Importance.Medium)
                .Build();

            result = TodoListDetailApimodelFactory.Create(srcTodoList);
        }

        [Fact]
        public void CorrectNumberOfTodoItems()
        {
            result.Items.Count.ShouldBe(5);
        }
    }
}