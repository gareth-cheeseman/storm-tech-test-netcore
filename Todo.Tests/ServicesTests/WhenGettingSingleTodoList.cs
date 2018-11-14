using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;
using Todo.Services;
using Todo.Tests.TodoListUtilities;
using Xunit;
using Shouldly;

namespace Todo.Tests.ServicesTests
{
    public class WhenGettingSingleTodoList : InMemoryDbTest
    {
        private TodoList srcTodoList { get; set; }
        private TodoList resultTodoList { get; set; }

        public WhenGettingSingleTodoList()
        {
            srcTodoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .WithItem("milk", Importance.High)
                .WithItem("cheese", Importance.Medium)
                .WithItem("lettuce", Importance.Low)
                .WithItem("tomato", Importance.Medium)
                .Build();

            WithContext(context =>
            {
                context.Add(srcTodoList);
                context.SaveChanges();
            });

            WithContext(context =>
            {
                resultTodoList = context.SingleTodoList(srcTodoList.TodoListId);
            });
        }

        [Fact]
        public void EqualTodoListId()
        {
           resultTodoList.TodoListId.ShouldBe(srcTodoList.TodoListId);

        }

        [Fact]
        public void EqualTitle()
        {
            resultTodoList.Title.ShouldBe(srcTodoList.Title);
        }

        [Fact]
        public void EqualItemsCount()
        {
            resultTodoList.Items.Count.ShouldBe(srcTodoList.Items.Count);
        }



    }
}
