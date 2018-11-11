using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
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
            Assert.Equal(srcTodoList.TodoListId, resultFields.TodoListId);
        }

        [Fact]
        public void EqualTitle()
        {
            Assert.Equal(srcTodoList.Title, resultFields.Title);
        }

        [Fact]
        public void EqualOwner()
        {
            Assert.Equal(srcTodoList.Owner.UserName, resultFields.Owner.UserName);
        }


        [Fact]
        public void EqualCountIsDone()
        {
            Assert.Equal(srcTodoList.Items.Count(i => !i.IsDone), resultFields.NumberOfNotDoneItems);
        }


    }
}