using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> GetTodos() => await _context.Todos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id) =>  Ok(await _context.Todos.FindAsync(id));

        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            await _context.Todos.AddAsync(todo);

            await _context.SaveChangesAsync();
            
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> EditTodo(Todo todo)
        {
            _context.Todos.Update(todo);

            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpDelete]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            _context.Remove(id);

            await _context.SaveChangesAsync();

            return NoContent();
        } 
    }
}