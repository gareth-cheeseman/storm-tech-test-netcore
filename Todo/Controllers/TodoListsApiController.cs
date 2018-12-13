using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Data.Entities;
using Todo.Services;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsApiController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserStore<IdentityUser> userStore;


        public TodoListsApiController(ApplicationDbContext dbContext, IUserStore<IdentityUser> userStore)
        {
            this.dbContext = dbContext;
            this.userStore = userStore;

        }

        // GET: api/TodoListsApi
        [HttpGet]
        public IEnumerable<TodoList> GetTodoLists()
        {
            return dbContext.TodoLists;
        }

        // GET: api/TodoListsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

//            var todoList = await dbContext.TodoLists.FindAsync(id);
            var todoList = await dbContext.SingleTodoListAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            return Ok(todoList);
        }

        // PUT: api/TodoListsApi/5
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

        // POST: api/TodoListsApi
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

        // DELETE: api/TodoListsApi/5
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