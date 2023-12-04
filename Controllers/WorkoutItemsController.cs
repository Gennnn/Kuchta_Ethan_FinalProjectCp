using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kuchta_Ethan_FinalProjectCp.Data;
using Kuchta_Ethan_FinalProjectCp.Models;

namespace Kuchta_Ethan_FinalProjectCp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutItemsController : ControllerBase
    {
        private readonly Kuchta_Ethan_FinalProjectCpContext _context;

        public WorkoutItemsController(Kuchta_Ethan_FinalProjectCpContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutItem>>> GetWorkoutItem()
        {
          if (_context.WorkoutItem == null)
          {
              return NotFound();
          }
            return await _context.WorkoutItem.ToListAsync();
        }

        // GET: api/WorkoutItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<WorkoutItem>>> GetWorkoutItem(int? id)
        {
            if (_context.WorkoutItem == null)
            {
                return NotFound();
            }
            if (id == null || id == -1)
            {
                var firstFiveItems = await _context.WorkoutItem.Take(5).ToListAsync();
                return firstFiveItems;
            }

            var item = await _context.WorkoutItem.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return new List<WorkoutItem> { item };
        }

        // PUT: api/WorkoutItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutItem(int id, WorkoutItem workoutItem)
        {
            if (id != workoutItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(workoutItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutItemExists(id))
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

        // POST: api/WorkoutItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutItem>> PostWorkoutItem(WorkoutItem workoutItem)
        {
          if (_context.WorkoutItem == null)
          {
              return Problem("Entity set 'Kuchta_Ethan_FinalProjectCpContext.WorkoutItem'  is null.");
          }
            _context.WorkoutItem.Add(workoutItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutItem", new { id = workoutItem.Id }, workoutItem);
        }

        // DELETE: api/WorkoutItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutItem(int id)
        {
            if (_context.WorkoutItem == null)
            {
                return NotFound();
            }
            var workoutItem = await _context.WorkoutItem.FindAsync(id);
            if (workoutItem == null)
            {
                return NotFound();
            }

            _context.WorkoutItem.Remove(workoutItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutItemExists(int id)
        {
            return (_context.WorkoutItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
