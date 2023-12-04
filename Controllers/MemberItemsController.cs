using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kuchta_Ethan_FinalProjectCP.Models;
using Kuchta_Ethan_FinalProjectCp.Data;
using Kuchta_Ethan_FinalProjectCp.Models;

namespace Kuchta_Ethan_FinalProjectCp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberItemsController : ControllerBase
    {
        private readonly Kuchta_Ethan_FinalProjectCpContext _context;

        public MemberItemsController(Kuchta_Ethan_FinalProjectCpContext context)
        {
            _context = context;
        }

        // GET: api/MemberItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberItem>>> GetMemberItem()
        {
          if (_context.MemberItem == null)
          {
              return NotFound();
          }
            return await _context.MemberItem.ToListAsync();
        }

        // GET: api/MemberItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MemberItem>>> GetMemberItem(int? id)
        {
            if (_context.MemberItem == null)
            {
                return NotFound();
            }
            if (id == null || id == -1)
            {
                var firstFiveItems = await _context.MemberItem.Take(5).ToListAsync();
                return firstFiveItems;
            }

            var item = await _context.MemberItem.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return new List<MemberItem> { item };
        }

        // PUT: api/MemberItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberItem(int id, MemberItem memberItem)
        {
            if (id != memberItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(memberItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberItemExists(id))
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

        // POST: api/MemberItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MemberItem>> PostMemberItem(MemberItem memberItem)
        {
          if (_context.MemberItem == null)
          {
              return Problem("Entity set 'Kuchta_Ethan_FinalProjectCpContext.MemberItem'  is null.");
          }
            _context.MemberItem.Add(memberItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberItem", new { id = memberItem.Id }, memberItem);
        }

        // DELETE: api/MemberItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberItem(int id)
        {
            if (_context.MemberItem == null)
            {
                return NotFound();
            }
            var memberItem = await _context.MemberItem.FindAsync(id);
            if (memberItem == null)
            {
                return NotFound();
            }

            _context.MemberItem.Remove(memberItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberItemExists(int id)
        {
            return (_context.MemberItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
