using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Todo.Services;

namespace Todo.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserStore<IdentityUser> userStore;


        public TodoListController(ApplicationDbContext dbContext, IUserStore<IdentityUser> userStore)
        {
            this.dbContext = dbContext;
            this.userStore = userStore;

        }

        // GET: api/TodoList
        [HttpGet]
        public IEnumerable<TodoList> GetTodoLists()
        {
            return dbContext.TodoLists;
        }

        // GET: api/TodoList/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoList = await dbContext.SingleTodoListAsync(id);

            if (todoList == null)
            {
                return NotFound();
            }

            var items = TodoListDetailApimodelFactory.Create(todoList);


            return Ok(items);
        }

        // PUT: api/TodoList/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList([FromRoute] int id, [FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoList.TodoListId)
            {
                return BadRequest();
            }

            dbContext.Entry(todoList).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoList
        [HttpPost]
        public async Task<IActionResult> PostTodoList([FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.TodoLists.Add(todoList);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetTodoList", new { id = todoList.TodoListId }, todoList);
        }

        // DELETE: api/TodoList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoList = await dbContext.TodoLists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            dbContext.TodoLists.Remove(todoList);
            await dbContext.SaveChangesAsync();

            return Ok(todoList);
        }

        private bool TodoListExists(int id)
        {
            return dbContext.TodoLists.Any(e => e.TodoListId == id);
        }
    }
}