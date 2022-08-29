using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using CountryApi.Modals;
using CountryApi.Repository.Models;
using CountryApi.Repository;

namespace CountryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryItemsController : ControllerBase
    {
        private readonly CountriesDbContext _context;

        public CountryItemsController(CountriesDbContext context)
        {
            _context = context;
        }

        // GET: api/CountryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryItem>>> GetCountryItems()
        {
           
          if (_context.Countries == null)
          {
              return NotFound();
          }
            return await _context.Countries.ToListAsync();
        }

        // GET: api/CountryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryItem>> GetCountryItem(string id)
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            var countryItem = await _context.Countries.FindAsync(id);

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
            var actualItem = _context.Countries.Where(country => country.Id == countryItem.Id).FirstOrDefault();

            if (actualItem == null)
            {
                return NotFound();
            }

            actualItem.Country = countryItem.Country;
            actualItem.Description = countryItem.Description;
            actualItem.IsDone = countryItem.IsDone;
            actualItem.Name = countryItem.Name;
            _context.SaveChanges();
            return Ok(actualItem);
        }
        // POST: api/CountryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryItem>> PostCountryItem(CountryItem countryItem)
        {
            Console.WriteLine(countryItem.Id);
          if (_context.Countries == null)
          {
              return Problem("Entity set 'CountryContext.CountryItems'  is null.");
          }
            _context.Countries.Add(countryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryItem", new { id = countryItem.Id }, countryItem);
        }

        // DELETE: api/CountryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryItem(string id)
        {
            if (_context.Countries == null)
            {
                return NotFound();
            }
            var countryItem = await _context.Countries.FindAsync(id);
            if (countryItem == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(countryItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryItemExists(string id)
        {
            return (_context.Countries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
