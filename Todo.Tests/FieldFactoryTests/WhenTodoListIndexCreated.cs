using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Shouldly;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.TodoLists;
using Todo.Tests.TodoListUtilities;
using Xunit;

namespace Todo.Tests.FieldFactoryTests
{
    public class WhenTodoListIndexCreated
    {
        private readonly IEnumerable<TodoList> srcTodoLists;
        private readonly TodoListIndexViewmodel resultFields;

        public WhenTodoListIndexCreated()
        {
            srcTodoLists = new List<TodoList>
            {

                new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                    .WithItem("bread", Importance.High)
                    .WithItem("milk", Importance.High)
                    .WithItem("cheese", Importance.Medium)
                    .WithItem("lettuce", Importance.Low)
                    .WithItem("tomato", Importance.Medium)
                    .Build(),
                new TestTodoListBuilder(new IdentityUser("alice@example.com"), "workshop")
                    .WithItem("timber", Importance.High)
                    .WithItem("saw", Importance.High)
                    .WithItem("drill", Importance.Medium)
                    .WithItem("bench", Importance.Low)
                    .WithItem("vacuum", Importance.Medium)
                    .Build()


            };

            resultFields = TodoListIndexViewmodelFactory.Create(srcTodoLists);
        }


        [Fact]
        public void EqualItemsCount()
        {
            resultFields.Lists.Count.ShouldBe(srcTodoLists.Count());
        }

    }
}