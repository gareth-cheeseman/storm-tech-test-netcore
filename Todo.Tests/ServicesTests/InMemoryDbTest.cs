using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Todo.Data;

namespace Todo.Tests.ServicesTests
{
    public class InMemoryDbTest : IDisposable
    {
        protected InMemoryDbTest()
        {
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            Options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(Connection)
                .Options;

            WithContext(context => context.Database.EnsureCreated());
        }

        private SqliteConnection Connection { get; }

        private DbContextOptions<ApplicationDbContext> Options { get; }

        protected void WithContext(Action<ApplicationDbContext> action)
        {
            using (var context = new ApplicationDbContext(Options))
            {
                action(context);
            }
        }

        public virtual void Dispose()
        {
            Connection?.Close();
        }
    }
}
