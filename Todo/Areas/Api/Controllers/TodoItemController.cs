using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Data.Entities;
using Todo.Filters;

namespace Todo.Areas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TodoItemController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/TodoItem
        [HttpGet]
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return context.TodoItems;
        }

        // GET: api/TodoItem/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // PUT: api/TodoItem/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutTodoItem([FromRoute] int id, [FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoItem.TodoItemId)
            {
                return BadRequest();
            }

            context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
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

        // POST: api/TodoItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostTodoItem([FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.TodoItemId }, todoItem);
        }

        // DELETE: api/TodoItem/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTodoItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();

            return Ok(todoItem);
        }

        private bool TodoItemExists(int id)
        {
            return context.TodoItems.Any(e => e.TodoItemId == id);
        }
    }
}