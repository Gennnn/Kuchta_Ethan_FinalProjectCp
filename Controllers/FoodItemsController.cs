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
    public class FoodItemsController : ControllerBase
    {
        private readonly Kuchta_Ethan_FinalProjectCpContext _context;

        public FoodItemsController(Kuchta_Ethan_FinalProjectCpContext context)
        {
            _context = context;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItem()
        {
          if (_context.FoodItem == null)
          {
              return NotFound();
          }
            return await _context.FoodItem.ToListAsync();
        }

        // GET: api/FoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItem(int? id)
        {
            if (_context.FoodItem == null)
            {
                return NotFound();
            }
            if (id == null || id == -1)
            {
                var firstFiveItems = await _context.FoodItem.Take(5).ToListAsync();
                return firstFiveItems;
            }

            var item = await _context.FoodItem.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return new List<FoodItem> { item };
        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItem(int id, FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(id))
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

        // POST: api/FoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFoodItem(FoodItem foodItem)
        {
          if (_context.FoodItem == null)
          {
              return Problem("Entity set 'Kuchta_Ethan_FinalProjectCpContext.FoodItem'  is null.");
          }
            _context.FoodItem.Add(foodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodItem", new { id = foodItem.Id }, foodItem);
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(int id)
        {
            if (_context.FoodItem == null)
            {
                return NotFound();
            }
            var foodItem = await _context.FoodItem.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItem.Remove(foodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodItemExists(int id)
        {
            return (_context.FoodItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
