using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using Todo.Data;
using Todo.Data.Entities;
using Todo.Tests.TodoListUtilities;
using Xunit;

namespace Todo.Tests.ServicesTests
{
   

    public class WhenGettingRelevantTodoLists
    {
        public Mock<IApplicationDbContext> DbContext { get; set; }
        public List<TodoList> SrcTodoLists { get; set; }


        public WhenGettingRelevantTodoLists()
        {
            DbContext = new Mock<IApplicationDbContext>();
            DbContext.SetupProperty(db => db.TodoLists);

            SrcTodoLists = new List<TodoList>
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

            DbContext.Object.TodoLists = new InternalDbSet<TodoList>();
        }

        [Fact]
        public void Whatever()
        {
            Assert.True(DbContext.Object.TodoLists.Count().Equals(2));
        }
    }
}
