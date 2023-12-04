using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kuchta_Ethan_FinalProjectCp.Data;
using Kuchta_Ethan_FinalProjectCp.Models;
using Kuchta_Ethan_FinalProjectCP.Models;

namespace Kuchta_Ethan_FinalProjectCp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleItemsController : ControllerBase
    {
        private readonly Kuchta_Ethan_FinalProjectCpContext _context;

        public ScheduleItemsController(Kuchta_Ethan_FinalProjectCpContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleItem>>> GetScheduleItem()
        {
          if (_context.ScheduleItem == null)
          {
              return NotFound();
          }
            return await _context.ScheduleItem.ToListAsync();
        }

        // GET: api/ScheduleItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ScheduleItem>>> GetScheduleItem(int? id)
        {
            if (_context.ScheduleItem == null)
            {
                return NotFound();
            }
            if (id == null || id == -1)
            {
                var firstFiveItems = await _context.ScheduleItem.Take(5).ToListAsync();
                return firstFiveItems;
            }

            var item = await _context.ScheduleItem.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return new List<ScheduleItem> { item };
        }

        // PUT: api/ScheduleItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleItem(int id, ScheduleItem scheduleItem)
        {
            if (id != scheduleItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(scheduleItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleItemExists(id))
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

        // POST: api/ScheduleItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleItem>> PostScheduleItem(ScheduleItem scheduleItem)
        {
          if (_context.ScheduleItem == null)
          {
              return Problem("Entity set 'Kuchta_Ethan_FinalProjectCpContext.ScheduleItem'  is null.");
          }
            _context.ScheduleItem.Add(scheduleItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleItem", new { id = scheduleItem.Id }, scheduleItem);
        }

        // DELETE: api/ScheduleItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleItem(int id)
        {
            if (_context.ScheduleItem == null)
            {
                return NotFound();
            }
            var scheduleItem = await _context.ScheduleItem.FindAsync(id);
            if (scheduleItem == null)
            {
                return NotFound();
            }

            _context.ScheduleItem.Remove(scheduleItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleItemExists(int id)
        {
            return (_context.ScheduleItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
