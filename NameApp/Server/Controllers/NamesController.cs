using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NameApp.Server.Data;
using NameApp.Shared;

namespace NameApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NamesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Names
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Name>>> GetNames()
        {            
            return await _context.Names.OrderByDescending(a => a.Amount).ToListAsync();
        }

        //GET: api/Names/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Name>> GetName(int id)
        {
            var name = await _context.Names.FindAsync(id);

            if (name == null)
            {
                return NotFound();
            }

            return name;
        }


        //GET: api/Names/countnames
        [HttpGet("countnames")]
        public async Task<int?> CountNames()
        {
            return await _context.Names.SumAsync(a => a.Amount);
        }

        // PUT: api/Names/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutName(int id, Name name)
        {
            if (id != name.Id)
            {
                return BadRequest();
            }

            _context.Entry(name).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NameExists(id))
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

        // POST: api/Names
        
        [HttpPost]
        public async Task<ActionResult<Name>> PostName(Name name)
        {            
            var allreadyInDb = _context.Names.Where(n => n.Nimi.ToLower() == name.Nimi.Trim().ToLower());

            if (allreadyInDb.Any())
            {
                return BadRequest();
            }
            else
            {
                _context.Names.Add(name);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetName", new { id = name.Id }, name);
            }          
        }

        // DELETE: api/Names/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteName(int id)
        {
            var name = await _context.Names.FindAsync(id);
            if (name == null)
            {
                return NotFound();
            }

            _context.Names.Remove(name);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NameExists(int id)
        {
            return _context.Names.Any(e => e.Id == id);
        }
    }
}
