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
    public class WhenTodoListDetailHidesDone
    {
        private readonly TodoList srcTodoList;
        private readonly TodoListDetailViewmodel resultFields;

        public WhenTodoListDetailHidesDone()
        {
            srcTodoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .WithItem("milk", Importance.High)
                .WithItem("cheese", Importance.Medium)
                .WithItem("lettuce", Importance.Low)
                .WithItem("tomato", Importance.Medium)
                .Build();

            srcTodoList.Items.FirstOrDefault().IsDone = true;

            resultFields = TodoListDetailViewmodelFactory.Create(srcTodoList, true);
        }

        [Fact]
        public void DoneItemsHidden()
        {
            resultFields.Items.All(item => item.IsDone).ShouldBeFalse();
           resultFields.Items.Count.ShouldBe(srcTodoList.Items.Count -1);
        }

    }
}