using Microsoft.AspNetCore.Identity;
using Shouldly;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Todo.Tests.TodoListUtilities;
using Xunit;

namespace Todo.Tests.FieldFactoryTests
{
    public class WhenTodoItemIsCreated
    {
        private readonly TodoList srcTodoList;
        private readonly TodoItemCreateFields resultFields;

        public WhenTodoItemIsCreated()
        {
            srcTodoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping").Build();
            
            resultFields = TodoItemCreateFieldsFactory.Create(srcTodoList, srcTodoList.Owner.Id);
        }

        [Fact]
        public void EqualTodoListId()
        {
            resultFields.TodoListId.ShouldBe(srcTodoList.TodoListId);
        }

        [Fact]
        public void EqualTitle()
        {
            resultFields.TodoListTitle.ShouldBe(srcTodoList.Title);
        }

        [Fact]
        public void ImportanceMedium()
        {
            resultFields.Importance.ShouldBe(Importance.Medium);
        }

        [Fact]
        public void EqualResponsiblePartyId()
        {
            resultFields.ResponsiblePartyId.ShouldBe(srcTodoList.Owner.Id);
        }
    }
}