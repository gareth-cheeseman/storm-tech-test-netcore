using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Todo.Data;
using Todo.Data.Entities;
using Todo.Services;
using Todo.Tests.TodoListUtilities;
using Xunit;

namespace Todo.Tests.ServicesTests
{
    public class WhenGettingRelevantTodoLists : InMemoryDbTest
    {
        private TodoList todoList1 { get; }
        private TodoList todoList2 { get; }


        public WhenGettingRelevantTodoLists()
        {
            todoList1 = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .WithItem("milk", Importance.High)
                .WithItem("cheese", Importance.Medium)
                .WithItem("lettuce", Importance.Low)
                .WithItem("tomato", Importance.Medium)
                .Build();
            todoList2 = new TestTodoListBuilder(new IdentityUser("bob@example.com"), "workshop")
                .WithItem("timber", Importance.High)
                .WithItem("saw", Importance.High)
                .WithItem("drill", Importance.Medium)
                .WithItem("bench", Importance.Low)
                .WithItem("vacuum", Importance.Medium)
                .Build();
        }


        [Fact]
        public void UserDoesNotGetListNotOwnerOrResponsible()
        {
            WithContext(context =>
            {
                context.AddRange(todoList1, todoList2);
                context.SaveChanges();
            });

            WithContext(context =>
            {
                context.RelevantTodoLists(todoList1.Owner.Id)
                    .Select(tl => tl.TodoListId)
                    .ToList()
                    .ShouldBe(new List<int>()
                    {
                        todoList1.TodoListId
                    });
            });
        }


        [Fact]
        public void UserGetsListOwnedAndResponsible()
        {
            WithContext(context =>
            {
                todoList2.Items.FirstOrDefault().ResponsiblePartyId = todoList1.Owner.Id;
                context.AddRange(todoList1, todoList2);
                context.SaveChanges();
            });

            WithContext(context =>
            {
                context.RelevantTodoLists(todoList1.Owner.Id)
                    .Select(tl => tl.TodoListId)
                    .OrderBy(id => id)
                    .ShouldBe(new List<int>
                    {
                        todoList1.TodoListId,
                        todoList2.TodoListId
                    }.OrderBy(id => id));
            });
        }
    }
}
