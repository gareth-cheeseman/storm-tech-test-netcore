using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Identity;
using Shouldly;
using Todo.Data.Entities;
using Todo.Services;
using Todo.Tests.TodoListUtilities;
using Xunit;

namespace Todo.Tests.ServicesTests
{
    public class WhenGettingSingleTodoItem : InMemoryDbTest
    {
        private TodoItem srcTodoItem { get; set; }
        private TodoItem resultTodoItem { get; set; }

        public WhenGettingSingleTodoItem()
        {
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .Build();

            srcTodoItem = todoList.Items.First();

            WithContext(context =>
            {
                context.Add(srcTodoItem);
                context.SaveChanges();
            });

            WithContext(context =>
            {
                resultTodoItem = context.SingleTodoItem(srcTodoItem.TodoItemId);
            });
        }

        [Fact]
        public void EqualTodoListId()
        {
            resultTodoItem.TodoListId.ShouldBe(srcTodoItem.TodoListId);

        }

        [Fact]
        public void EqualTitle()
        {
            resultTodoItem.Title.ShouldBe(srcTodoItem.Title);
        }

        [Fact]
        public void EqualImportance()
        {
            resultTodoItem.Importance.ShouldBe(srcTodoItem.Importance);
        }



    }
}