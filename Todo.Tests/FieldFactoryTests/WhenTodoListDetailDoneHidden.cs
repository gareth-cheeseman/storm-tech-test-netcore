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
    public class WhenTodoListDetailDoneHidden
    {
        private readonly TodoList srcTodoList;
        private readonly TodoListDetailViewmodel resultFields;

        public WhenTodoListDetailDoneHidden()
        {
            srcTodoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .WithItem("milk", Importance.High)
                .WithItem("cheese", Importance.Medium)
                .WithItem("lettuce", Importance.Low)
                .WithItem("tomato", Importance.Medium)
                .Build();

            srcTodoList.Items.First().IsDone = true;

            resultFields = TodoListDetailViewmodelFactory.Create(srcTodoList, hideDone: true, orderByRank: false);
        }

        [Fact]
        public void NoDoneItems()
        {
            resultFields.Items.ShouldAllBe(ti => !ti.IsDone);
        }

        [Fact]
        public void EqualCount()
        {
            resultFields.Items.Count.ShouldBe(4);
        }

      

    }
}