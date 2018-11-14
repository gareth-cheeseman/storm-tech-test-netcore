using System.Collections.Generic;
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
    public class WhenTodoListIsConvertedToSummaryView
    {
        private readonly TodoList srcTodoList;
        private readonly TodoListSummaryViewmodel resultFields;

        public WhenTodoListIsConvertedToSummaryView()
        {
            srcTodoList =


                new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                    .WithItem("bread", Importance.High)
                    .WithItem("milk", Importance.High)
                    .WithItem("cheese", Importance.Medium)
                    .WithItem("lettuce", Importance.Low)
                    .WithItem("tomato", Importance.Medium)
                    .Build();
            
            

            resultFields = TodoListSummaryViewmodelFactory.Create(srcTodoList);
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
        public void EqualOwner()
        {
            resultFields.Owner.UserName.ShouldBe(srcTodoList.Owner.UserName);
        }


        [Fact]
        public void EqualCountIsDone()
        {
            resultFields.NumberOfNotDoneItems.ShouldBe(srcTodoList.Items.Count(item => !item.IsDone));
        }


    }
}