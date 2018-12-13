using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Data.Entities;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoListsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TodoListsApi
        [HttpGet]
        public IEnumerable<TodoList> GetTodoLists()
        {
            return _context.TodoLists;
        }

        // GET: api/TodoListsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoList = await _context.TodoLists.FindAsync(id);

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

            _context.Entry(todoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            _context.TodoLists.Add(todoList);
            await _context.SaveChangesAsync();

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

            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            _context.TodoLists.Remove(todoList);
            await _context.SaveChangesAsync();

            return Ok(todoList);
        }

        private bool TodoListExists(int id)
        {
            return _context.TodoLists.Any(e => e.TodoListId == id);
        }
    }
}