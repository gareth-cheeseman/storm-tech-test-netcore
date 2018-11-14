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
    public class WhenTodoListDetailOrderedByRank
    {
        private readonly TodoList srcTodoList;
        private readonly TodoListDetailViewmodel resultFields;

        public WhenTodoListDetailOrderedByRank()
        {
            srcTodoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .WithItem("milk", Importance.High)
                .WithItem("cheese", Importance.Medium)
                .WithItem("lettuce", Importance.Low)
                .WithItem("tomato", Importance.Medium)
                .Build();

            srcTodoList.Items.ElementAt(0).Rank = 5;
            srcTodoList.Items.ElementAt(1).Rank = 4;
            srcTodoList.Items.ElementAt(2).Rank = 3;
            srcTodoList.Items.ElementAt(3).Rank = 2;
            srcTodoList.Items.ElementAt(4).Rank = 1;


            resultFields = TodoListDetailViewmodelFactory.Create(srcTodoList, hideDone: false, orderByRank: true);
        }

        [Fact]
        public void IsOrdered()
        {
            resultFields.Items.ShouldBe(resultFields.Items.OrderBy(ti => ti.Rank));
        }



      

    }
}