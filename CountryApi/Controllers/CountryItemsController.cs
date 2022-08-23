using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CountryApi.Modals;

namespace CountryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryItemsController : ControllerBase
    {
        private readonly CountryContext _context;

        public CountryItemsController(CountryContext context)
        {
            _context = context;
        }

        // GET: api/CountryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryItem>>> GetCountryItems()
        {
           
          if (_context.CountryItems == null)
          {
              return NotFound();
          }
            return await _context.CountryItems.ToListAsync();
        }

        // GET: api/CountryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryItem>> GetCountryItem(string id)
        {
          if (_context.CountryItems == null)
          {
              return NotFound();
          }
            var countryItem = await _context.CountryItems.FindAsync(id);

            if (countryItem == null)
            {
                return NotFound();
            }

            return countryItem;
        }

        // PUT: api/CountryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult<CountryItem>> PutCountryItem(CountryItem countryItem)
        {
            var actualItem = _context.CountryItems.Where(country => country.Id == countryItem.Id).FirstOrDefault();

            if (actualItem == null)
            {
                return NotFound();
            }

            actualItem.Country = countryItem.Country;
            actualItem.description = countryItem.description;
            actualItem.IsDone = countryItem.IsDone;
            actualItem.name = countryItem.name;
            _context.SaveChanges();
            return Ok(actualItem);
        }
        // POST: api/CountryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryItem>> PostCountryItem(CountryItem countryItem)
        {
            Console.WriteLine(countryItem.Id);
          if (_context.CountryItems == null)
          {
              return Problem("Entity set 'CountryContext.CountryItems'  is null.");
          }
            _context.CountryItems.Add(countryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryItem", new { id = countryItem.Id }, countryItem);
        }

        // DELETE: api/CountryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryItem(string id)
        {
            if (_context.CountryItems == null)
            {
                return NotFound();
            }
            var countryItem = await _context.CountryItems.FindAsync(id);
            if (countryItem == null)
            {
                return NotFound();
            }

            _context.CountryItems.Remove(countryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryItemExists(string id)
        {
            return (_context.CountryItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
