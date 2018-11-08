using Microsoft.AspNetCore.Identity;
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
            Assert.Equal(srcTodoList.TodoListId, resultFields.TodoListId);
        }

        [Fact]
        public void EqualTitle()
        {
            Assert.Equal(srcTodoList.Title, resultFields.TodoListTitle);
        }

        [Fact]
        public void ImportanceMedium()
        {
            Assert.Equal(Importance.Medium, resultFields.Importance);
        }

        [Fact]
        public void EqualResponsiblePartyId()
        {
            Assert.Equal(srcTodoList.Owner.Id, resultFields.ResponsiblePartyId);
        }
    }
}